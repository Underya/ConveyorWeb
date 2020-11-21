//Функция обновления содержимого массива
function UpdatePanel() {
    //Сначала очищается содержимое панели
    let panel = document.getElementById("conveyor_panel");
    panel.innerHTML = "";
    //Запрос, на получение нового содержимого

    //Заполнение содержимым
    let product = document.createElement('div');
    let product2 = document.createElement('div');
    let product_class = "conveyor-product";
    let good_class = product_class + " " + "conveyor-product-good";
    let defective_class = product_class + " " + "conveyor-panel-defective";
    product.className = good_class;
    product2.className = defective_class;
    panel.appendChild(product);
    panel.appendChild(product2);
}

//Функция возвращает новый продукт
//Зависящий от типа
function GetNewProdyct(type) {
    //Создание нового продукта
    let product = document.createElement('div');
    //Указание типа в зависимости от 
}

//Функция, инициализирующая страницу
function LoadPage() {
    //Заполнение панели
    UpdatePanel();
}