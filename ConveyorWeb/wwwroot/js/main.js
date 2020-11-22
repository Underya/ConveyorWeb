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


//Метод для вывода ошибки пользователю
function ShowError(errorText) {
    alert(errorText);
}

//Запрос на добавление новой продукции в конвеер
function addButtonClick() {
    //Получение типа продукта, который надо добавить
    let Addr = "https://localhost:44367/main/AddProduct";
    let good = document.getElementById("goodradio");
    let defective = document.getElementById("defectiveradio")
    if (good.checked)
        Addr += "?type=good";
    if (defective.checked)
        Addr += "?type=defective";

    let xhr = new XMLHttpRequest();
    xhr.open('GET', Addr, false);
    //xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send();
    if (xhr.status != 200) {
        let error_text = "Не удалось добавить продукт: ";
        error_text += xhr.responseText;
        ShowError(error_text);
    }
    //Обновление страницы
    UpdatePanel();
}

//Запрос на извлечение конвеера с ленты
function pushButtonClick() {
    let Addr = "https://localhost:44367/main/pushproduct";
    let xhr = new XMLHttpRequest();
    xhr.open("POST", Addr, false);
    xhr.send();
    if (xhr.status != 200) {
        let error_text = "Не удалось извлечь продукт: ";
        error_text += xhr.responseText;
        ShowError(error_text);
    }
    //Обновление страницы
    UpdatePanel();
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