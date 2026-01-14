using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибках работы с устройством TMK
    /// </summary>
    public class TMKDeviceException : TMKException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKDeviceException"/>
        /// </summary>
        public TMKDeviceException()
            : base("Ошибка работы устройства TMK")
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKDeviceException"/> с указанным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKDeviceException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKDeviceException"/> с указанным сообщением и кодом ошибки
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        public TMKDeviceException(string message, int errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKDeviceException"/> с указанным сообщением, кодом ошибки и номером устройства
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        /// <param name="deviceNumber">Номер устройства</param>
        public TMKDeviceException(string message, int errorCode, int deviceNumber)
            : base(message, errorCode, deviceNumber)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKDeviceException"/> с указанным сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public TMKDeviceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
