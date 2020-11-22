using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorWebServer
{
    /// <summary>
    /// Конвеер с продуктами, который могут быть в нескольких состояних
    /// </summary>
    public interface IConveyor
    {
        /// <summary>
        /// Добавление нового продукта
        /// </summary>
        /// <param name="Type">Тип продукта. 1 - хороший, 2 - бракованный</param>
        public void AddProduct(int Type);

        /// <summary>
        /// Вытолкнуть объект с ленты
        /// </summary>
        public void PushProdcut();

        /// <summary>
        /// Получение состояния объекта
        /// </summary>
        public List<int> State { get; }

    }
}
