using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибках конфигурации устройства TMK
    /// </summary>
    public class TMKConfigurationException : TMKException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKConfigurationException"/>
        /// </summary>
        public TMKConfigurationException()
            : base("Ошибка конфигурации устройства TMK")
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKConfigurationException"/> с указанным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKConfigurationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKConfigurationException"/> с указанным сообщением и кодом ошибки
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        public TMKConfigurationException(string message, int errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKConfigurationException"/> с указанным сообщением, кодом ошибки и номером устройства
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        /// <param name="deviceNumber">Номер устройства</param>
        public TMKConfigurationException(string message, int errorCode, int deviceNumber)
            : base(message, errorCode, deviceNumber)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKConfigurationException"/> с указанным сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public TMKConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
