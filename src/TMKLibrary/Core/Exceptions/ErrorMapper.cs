using System;
using System.Collections.Generic;
using System.Text;
using TMKLibrary.Core.Enums;

namespace TMKLibrary.Core.Exceptions
{
    /// <summary>
    /// Утилита для преобразования нативных кодов ошибок в исключения
    /// </summary>
    public static class ErrorMapper
    {


        /// <summary>
        /// Проверяет код ошибки и генерирует исключение если ошибка обнаружена
        /// </summary>
        /// <param name="errorCode">Код ошибки TMK</param>
        /// <param name="operationDescription">Описание операции (для сообщения об ошибке)</param>
        /// <param name="deviceNumber">Номер устройства (опционально)</param>
        /// <exception cref="TMKConfigurationException">Ошибка конфигурации</exception>
        /// <exception cref="TMKDeviceException">Ошибка устройства</exception>
        /// <exception cref="TMKTimeoutException">Таймаут</exception>
        /// <exception cref="TMKInvalidParameterException">Неверный параметр</exception>
        /// <exception cref="TMKException">Общая ошибка</exception>
        public static void ThrowIfError(int errorCode, string operationDescription = "", int? deviceNumber = null)
        {
            if (errorCode == (int)TMKError.Success)
            {
                return;
            }

            var message = GetErrorMessage((TMKError)errorCode, operationDescription);

            switch ((TMKError)errorCode)
            {
                case TMKError.BadNumber:
                case TMKError.BadAddress:
                case TMKError.BadParameter:
                    if (deviceNumber.HasValue)
                        throw new TMKInvalidParameterException(message, errorCode, deviceNumber.Value);
                    else
                        throw new TMKInvalidParameterException(message, errorCode);

                case TMKError.BadMode:
                case TMKError.ConfigError:
                    if (deviceNumber.HasValue)
                        throw new TMKConfigurationException(message, errorCode, deviceNumber.Value);
                    else
                        throw new TMKConfigurationException(message, errorCode);

                case TMKError.Timeout:
                    if (deviceNumber.HasValue)
                        throw new TMKTimeoutException(message, errorCode, 0);
                    else
                        throw new TMKTimeoutException(message, errorCode, 0);

                case TMKError.NotOpened:
                case TMKError.Busy:
                case TMKError.BadVersion:
                case TMKError.IoError:
                    if (deviceNumber.HasValue)
                        throw new TMKDeviceException(message, errorCode, deviceNumber.Value);
                    else
                        throw new TMKDeviceException(message, errorCode);

                default:
                    if (deviceNumber.HasValue)
                        throw new TMKException(message, errorCode, deviceNumber.Value);
                    else
                        throw new TMKException(message, errorCode);
            }
        }

        /// <summary>
        /// Получает описание ошибки по коду
        /// </summary>
        /// <param name="error">Код ошибки</param>
        /// <param name="operationDescription">Описание операции</param>
        /// <returns>Сообщение об ошибке</returns>
        public static string GetErrorMessage(TMKError error, string operationDescription = "")
        {
            var errorMessage = error switch
            {
                TMKError.Success => "Операция выполнена успешно",
                TMKError.BadNumber => "Неверный номер устройства",
                TMKError.BadMode => "Неверный режим работы устройства",
                TMKError.BadAddress => "Неверный адрес памяти или RT адрес",
                TMKError.BadParameter => "Неверный параметр",
                TMKError.NotOpened => "Устройство не открыто",
                TMKError.Busy => "Устройство занято",
                TMKError.Timeout => "Превышено время ожидания",
                TMKError.BadVersion => "Несовместимая версия драйвера",
                TMKError.ConfigError => "Ошибка конфигурации устройства",
                TMKError.IoError => "Ошибка ввода-вывода",
                _ => $"Неизвестная ошибка (код {(int)error})"
            };

            if (!string.IsNullOrEmpty(operationDescription))
            {
                return $"{errorMessage} при выполнении операции: {operationDescription}";
            }

            return errorMessage;
        }

        /// <summary>
        /// Проверяет успешность выполнения операции
        /// </summary>
        /// <param name="errorCode">Код ошибки</param>
        /// <returns>true если операция успешна, иначе false</returns>
        public static bool IsSuccess(int errorCode)
        {
            return errorCode == (int)TMKError.Success;
        }

        /// <summary>
        /// Проверяет наличие ошибки
        /// </summary>
        /// <param name="errorCode">Код ошибки</param>
        /// <returns>true если есть ошибка, иначе false</returns>
        public static bool IsError(int errorCode)
        {
            return errorCode != (int)TMKError.Success;
        }

    }
}
