using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Runtime.CompilerServices;

namespace ConveyorWeb
{
    /// <summary>
    /// Возможные типы продуктов
    /// </summary>
    public enum ProductType
    {
        good = 1,
        defective = 2
    }

    /// <summary>
    /// Один продукт конвеерной ленты
    /// </summary>
    public class ProductObject
    {
        /// <summary>
        /// Тип продукта
        /// </summary>
        ProductType type;

        /// <summary>
        ///Уникальный идентификатор одного объекта
        /// </summary>
        int id = 0;

        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Свойство для выдачи уникальных id объектам
        /// </summary>
        static int share_id = 1;

        /// <summary>
        /// Создание нового продукта, с указанием типа
        /// </summary>
        /// <param name="Type"></param>
        public ProductObject(ProductType Type)
        {
            //Сохрание типа
            type = Type;
            //Выдача нового id
            id = share_id++;
        }

        /// <summary>
        /// Тип продукта
        /// </summary>
        public ProductType Type { get { return type; } }

        /// <summary>
        /// Является ли объект годным
        /// </summary>
        /// <returns></returns>
        public bool IsGood()
        {
            if (type == ProductType.good)
                return true;
            return false;
        }

        /// <summary>
        /// Является ли продукт бракованным
        /// </summary>
        /// <returns></returns>
        public bool IsDefective()
        {
            if (type == ProductType.defective)
                return true;
            return false;
        }
    }
}
