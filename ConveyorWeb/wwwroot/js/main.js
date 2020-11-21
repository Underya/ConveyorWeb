//Функция обновления содержимого массива
function UpdatePanel() {
    //Сначала очищается содержимое панели
    let panel = document.getElementById("conveyor_panel");
    panel.innerHTML = "";
    
    //Запрос, на получение нового содержимого
    var xhr = new XMLHttpRequest();
    xhr.open('POST', "https://localhost:44367/main/state", false);
    xhr.send();
    //Получение массива значений
    var products = JSON.parse(xhr.responseText);
    //Получение отдельных продуктов
    for (index = 0; index < products.length; index++) {
        //Получение и добавление продукта
        panel.appendChild(GetNewProdyct(products[index]));
    }
}

//Функция возвращает новый продукт
//Зависящий от типа
function GetNewProdyct(type) {
    //Создание нового продукта
    let product = document.createElement('div');
    //Указание класса в зависимости от типа
    let product_class = "conveyor-product";
    if (type == "good")
        product_class += " " + "conveyor-product-good";
    else if (type == "defective")
        product_class += " " + "conveyor-product-defective";
    else {
        //Если ни один из типов не подходит, выбросить ошибку
        alert("Непредведенный тип!");
    }

    //Указние стиля
    product.className = product_class;
    //Возвращение объекта
    return product;
}

//Функция, инициализирующая страницу
function LoadPage() {
    //Заполнение панели
    UpdatePanel();
}