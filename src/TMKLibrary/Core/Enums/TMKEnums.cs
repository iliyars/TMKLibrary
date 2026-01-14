using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Enums
{
    /// <summary>
    /// Режимы работы устройства TMK
    /// </summary>
    public enum DeviceMode
    {
        /// <summary>
        /// Режим не установлен
        /// </summary>
        None = 0,

        /// <summary>
        /// Режим Bus Controller (Контроллер Канала)
        /// </summary>
        BusController = 1,

        /// <summary>
        /// Режим Remote Terminal (Оконечное Устройство)
        /// </summary>
        RemoteTerminal = 2,

        /// <summary>
        /// Режим Bus Monitor (Монитор)
        /// </summary>
        BusMonitor = 3
    }

    /// <summary>
    /// Номер шины MIL-STD-1553B
    /// </summary>
    public enum BusNumber
    {
        /// <summary>
        /// Шина A (основная)
        /// </summary>
        BusA = 0,

        /// <summary>
        /// Шина B (резервная)
        /// </summary>
        BusB = 1
    }

    /// <summary>
    /// Режимы прерываний для Bus Controller
    /// </summary>
    [Flags]
    public enum BCInterruptMode
    {
        /// <summary>
        /// Без прерываний
        /// </summary>
        None = 0,

        /// <summary>
        /// Прерывание при старте
        /// </summary>
        OnStart = 0x0001,

        /// <summary>
        /// Прерывание при остановке
        /// </summary>
        OnStop = 0x0002,

        /// <summary>
        /// Прерывание при завершении
        /// </summary>
        OnDone = 0x0004,

        /// <summary>
        /// Прерывание по ошибке
        /// </summary>
        OnError = 0x0008
    }

    /// <summary>
    /// Режимы прерываний для Remote Terminal
    /// </summary>
    [Flags]
    public enum RTInterruptMode
    {
        /// <summary>
        /// Без прерываний
        /// </summary>
        None = 0,

        /// <summary>
        /// Прерывание при приеме командного слова
        /// </summary>
        OnCommandWord = 0x0001,

        /// <summary>
        /// Прерывание при приеме широковещательной команды
        /// </summary>
        OnBroadcast = 0x0002
    }

    /// <summary>
    /// Типы команд MIL-STD-1553B
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// Прием данных BC->RT
        /// </summary>
        BcToRt = 0x00,

        /// <summary>
        /// Передача данных RT->BC
        /// </summary>
        RtToBc = 0x01,

        /// <summary>
        /// Передача данных RT->RT
        /// </summary>
        RtToRt = 0x02,

        /// <summary>
        /// Управляющая команда без данных
        /// </summary>
        Control = 0x03,

        /// <summary>
        /// Управляющая команда с данными
        /// </summary>
        ControlWithData = 0x04,

        /// <summary>
        /// Широковещательная команда BC->RT
        /// </summary>
        BroadcastBcToRt = 0x08,

        /// <summary>
        /// Широковещательная команда RT->RT
        /// </summary>
        BroadcastRtToRt = 0x0A,

        /// <summary>
        /// Широковещательная управляющая команда
        /// </summary>
        BroadcastControl = 0x0B,

        /// <summary>
        /// Широковещательная управляющая команда с данными
        /// </summary>
        BroadcastControlWithData = 0x0C
    }

    /// <summary>
    /// Управляющие команды MIL-STD-1553B (режимные коды)
    /// </summary>
    public enum ModeCode
    {
        /// <summary>
        /// Динамическое управление шиной
        /// </summary>
        DynamicBusControl = 0x00,

        /// <summary>
        /// Синхронизация (с данными)
        /// </summary>
        SynchronizeWithData = 0x01,

        /// <summary>
        /// Передать слово состояния
        /// </summary>
        TransmitStatusWord = 0x02,

        /// <summary>
        /// Инициировать самотестирование (с данными)
        /// </summary>
        InitiateSelfTestWithData = 0x03,

        /// <summary>
        /// Передать адрес передающего ОУ
        /// </summary>
        TransmitLastCommand = 0x04,

        /// <summary>
        /// Передать слово встроенного контроля
        /// </summary>
        TransmitBitWord = 0x05,

        /// <summary>
        /// Выбрать передатчик в режим выключения
        /// </summary>
        SelectedTransmitterShutdown = 0x06,

        /// <summary>
        /// Отменить выбор передатчика
        /// </summary>
        OverrideTransmitterShutdown = 0x07,

        /// <summary>
        /// Запретить передачу
        /// </summary>
        InhibitTerminalFlag = 0x08,

        /// <summary>
        /// Отменить запрет передачи
        /// </summary>
        OverrideInhibitTerminalFlag = 0x09,

        /// <summary>
        /// Установить векторное слово (с данными)
        /// </summary>
        ResetRemoteTerminal = 0x10,

        /// <summary>
        /// Передать векторное слово
        /// </summary>
        TransmitVectorWord = 0x11,

        /// <summary>
        /// Синхронизация (без данных)
        /// </summary>
        SynchronizeWithoutData = 0x12,

        /// <summary>
        /// Передать адрес последней команды
        /// </summary>
        TransmitLastCommandWord = 0x13,

        /// <summary>
        /// Инициировать самотестирование (без данных)
        /// </summary>
        InitiateSelfTestWithoutData = 0x14
    }

    /// <summary>
    /// Биты управляющего слова (Control Word)
    /// </summary>
    [Flags]
    public enum ControlWordBits : ushort
    {
        /// <summary>
        /// Нет установленных битов
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Выбор шины A
        /// </summary>
        BusA = 0x0000,

        /// <summary>
        /// Выбор шины B
        /// </summary>
        BusB = 0x0001,

        /// <summary>
        /// Разрешение прерываний
        /// </summary>
        InterruptEnable = 0x0002,

        /// <summary>
        /// Режим BC (Контроллер Канала)
        /// </summary>
        ModeBc = 0x0000,

        /// <summary>
        /// Режим RT (Оконечное Устройство)
        /// </summary>
        ModeRt = 0x0004,

        /// <summary>
        /// Режим MT (Монитор)
        /// </summary>
        ModeMt = 0x0008,

        /// <summary>
        /// Сброс контроллера
        /// </summary>
        Reset = 0x0010
    }

    /// <summary>
    /// Биты ответного слова RT (Status Word)
    /// </summary>
    [Flags]
    public enum StatusWordBits : ushort
    {
        /// <summary>
        /// Нет установленных битов
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Ошибка (бит 9)
        /// </summary>
        MessageError = 0x0200,

        /// <summary>
        /// Оборудование занято (бит 10)
        /// </summary>
        Instrumentation = 0x0400,

        /// <summary>
        /// Запрос обслуживания (бит 11)
        /// </summary>
        ServiceRequest = 0x0800,

        /// <summary>
        /// Зарезервировано (биты 12-13)
        /// </summary>
        Reserved = 0x3000,

        /// <summary>
        /// Широковещательная команда принята (бит 14)
        /// </summary>
        BroadcastCommandReceived = 0x4000,

        /// <summary>
        /// Занят (бит 15)
        /// </summary>
        Busy = 0x8000,

        /// <summary>
        /// Адрес терминала (биты 4-8)
        /// </summary>
        TerminalAddressMask = 0x1F00,

        /// <summary>
        /// Маска для всех флагов состояния
        /// </summary>
        AllFlags = MessageError | Instrumentation | ServiceRequest | BroadcastCommandReceived | Busy
    }

    /// <summary>
    /// Коды ошибок TMK
    /// </summary>
    public enum TMKError
    {
        /// <summary>
        /// Нет ошибки
        /// </summary>
        Success = 0,

        /// <summary>
        /// Неверный номер устройства
        /// </summary>
        BadNumber = 1,

        /// <summary>
        /// Неверный режим
        /// </summary>
        BadMode = 2,

        /// <summary>
        /// Неверный адрес
        /// </summary>
        BadAddress = 3,

        /// <summary>
        /// Неверный параметр
        /// </summary>
        BadParameter = 4,

        /// <summary>
        /// Устройство не открыто
        /// </summary>
        NotOpened = 5,

        /// <summary>
        /// Устройство занято
        /// </summary>
        Busy = 6,

        /// <summary>
        /// Таймаут операции
        /// </summary>
        Timeout = 7,

        /// <summary>
        /// Неверная версия драйвера
        /// </summary>
        BadVersion = 8,

        /// <summary>
        /// Ошибка конфигурации
        /// </summary>
        ConfigError = 9,

        /// <summary>
        /// Ошибка ввода-вывода
        /// </summary>
        IoError = 10
    }

    /// <summary>
    /// Состояние Bus Controller
    /// </summary>
    public enum BCState
    {
        /// <summary>
        /// Остановлен
        /// </summary>
        Stopped = 0,

        /// <summary>
        /// Работает
        /// </summary>
        Running = 1,

        /// <summary>
        /// Приостановлен
        /// </summary>
        Paused = 2
    }

    /// <summary>
    /// Состояние Remote Terminal
    /// </summary>
    public enum RTState
    {
        /// <summary>
        /// Отключен
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Включен
        /// </summary>
        Enabled = 1,

        /// <summary>
        /// Занят
        /// </summary>
        Busy = 2
    }

    /// <summary>
    /// Состояние Bus Monitor
    /// </summary>
    public enum MTState
    {
        /// <summary>
        /// Остановлен
        /// </summary>
        Stopped = 0,

        /// <summary>
        /// Работает
        /// </summary>
        Running = 1
    }

    /// <summary>
    /// Константы MIL-STD-1553B
    /// </summary>
    public static class MilStd1553Constants
    {
        /// <summary>
        /// Максимальный адрес RT (0-31)
        /// </summary>
        public const int MaxRtAddress = 31;

        /// <summary>
        /// Максимальный номер субадреса (0-31)
        /// </summary>
        public const int MaxSubaddress = 31;

        /// <summary>
        /// Максимальное количество слов данных (1-32)
        /// </summary>
        public const int MaxWordCount = 32;

        /// <summary>
        /// Широковещательный адрес
        /// </summary>
        public const int BroadcastAddress = 31;

        /// <summary>
        /// Размер слова данных (16 бит)
        /// </summary>
        public const int WordSizeBits = 16;

        /// <summary>
        /// Минимальный интервал между командами (мкс)
        /// </summary>
        public const int MinInterCommandGapUs = 4;

        /// <summary>
        /// Максимальное время ответа RT (мкс)
        /// </summary>
        public const int MaxRtResponseTimeUs = 14;
    }
}
