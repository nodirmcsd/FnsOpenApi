using System;

namespace FnsOpenApi.Domain.Models
{
    /// <summary>
    /// Чек
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Сумма чека
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// Дата и время пробития чека yyyy-MM-ddTHH:mm:ss - секунды не передаются
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Номер фискальный накопитель (ФН)
        /// </summary>
        public string Fn { get; set; }
        
        /// <summary>
        /// Тип операции 
        /// </summary>
        public int Operation { get; set; } = 1;
        
        /// <summary>
        /// Номер фискального документы (ФД)
        /// </summary>
        public string Fd { get; set; }
        
        /// <summary>
        /// Фискальный признак документа (ФП)
        /// </summary>
        public string Fp { get; set; }
    }
}