using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorWeb
{
    /// <summary>
    /// Конвейр основанный на реализации очереди
    /// </summary>
    public class QueueConveyor :
        IConveyor
    {
        /// <summary>
        /// Очередь со всеми элементам
        /// </summary>
        Queue<ProductObject> queue = null;

        /// <summary>
        /// Максимальный размер стека
        /// </summary>
        int maxSize = 0;

        /// <summary>
        /// Создание нового коневейра
        /// </summary>
        /// <param name="MaxCount">Максимальное количество элементов в очереди</param>
        public QueueConveyor(int MaxCount = 5)
        {
            queue = new Queue<ProductObject>();
            maxSize = MaxCount;
        }

        /// <summary>
        /// Получение актуального состоояния конвеереа
        /// </summary>
        public List<int> State { get 
            {
                List<int> conveyorState = new List<int>();

                //Перевод очерди в ообщий тип
                foreach(ProductObject product in queue)
                {
                    //В зависимоти от стояния добавляется объект, с номером аналогичным состоянием
                    if (product.IsGood())
                        conveyorState.Add(1);
                    if (product.IsDefective())
                        conveyorState.Add(2);
                }

                return conveyorState;
            } }

        /// <summary>
        /// Добавление нового объекта на конвеер
        /// </summary>
        /// <param name="Type">Тип нового продукта; 1 - Хороший; 2 - Брак</param>
        public void AddProduct(int Type)
        {
            //Проверка, есть ли место в очереди
            if (queue.Count == maxSize)
                throw new Exception("Нельзя добавить новый объект. Очередь полная");

            //Тип нового объекта
            ProductType type = (ProductType)Type;
            switch (Type)
            {
                //1 - значит хороший продукт
                case 1:
                    type = ProductType.good;
                    break;

                //2 - дефективный продукт
                case 2:
                    type = ProductType.defective;
                    break;

                //Если ни одного из значений не подходит - выбросить ошибку
                default:
                    throw new InvalidCastException("Не правильный код типа");
            }

            //Создание нового объекта
            ProductObject product = new ProductObject(type);

            //Добавление новго продукта
            queue.Enqueue(product);
        }

        /// <summary>
        /// Удалить продукт из очереди
        /// </summary>
        public void PushProdcut()
        {
            //Если в очереди нет элементов, выкинуть ошибку
            if (queue.Count == 0)
                throw new Exception("В очереди нет элементов");

            //Удалить элемент из очереди
            queue.Dequeue();
        }
    }
}
