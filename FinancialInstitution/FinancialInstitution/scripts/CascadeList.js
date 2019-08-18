countries_dictionary = {
    "США":["Нью-Йорк", "Сан-Франциско", "Лос-Анджелес"],
    "Беларусь": ["Могилев", "Минск", "Витебск"],
    "Россия": ["Вологда", "Москва", "Санкт-Петербург"],
    "Украина": ["Киев", "Львов", "Одесса"]
};
var countryList = document.getElementById('country');
var cityList = document.getElementById('city');



    window.onload = function () {

        if (countryList == null)
            return;
        countryList.options[0].setAttribute("disabled", null);
        countryList.options[0].setAttribute("selected", null);
        cityList.setAttribute("disabled", null);





        if (countryList.options.length === 1)
            countryList.options[0].setAttribute("selected", null);

        //for (var key in countries_dictionary) {
        //    countryList.innerHTML += "<option>" + key + "</option>";
        //}
        countryList.options[0].setAttribute("disabled", null);

        for (var key in countries_dictionary)
            if (key != countryList.options[countryList.selectedIndex].value)
                countryList.innerHTML += "<option>" + key + "</option>";

        var selected = countryList.options[countryList.selectedIndex].value;

        for (var key in countries_dictionary[selected])
            if (countries_dictionary[selected][key] != cityList.options[cityList.selectedIndex].value)
                cityList.innerHTML += "<option>" + countries_dictionary[selected][key] + "</option>";
    }

    function countrySelected() {
        if (cityList == null)
            return;
        cityList.innerHTML = "<option>Город</option>";

        var selected = countryList.options[countryList.selectedIndex].value;
        cityList.options[0].setAttribute("disabled", null);
        cityList.options[0].setAttribute("selected", null);
        cityList.removeAttribute("disabled");

        for (var key in countries_dictionary[selected]) {
            cityList.innerHTML += "<option>" + countries_dictionary[selected][key] + "</option>";
        }
    }
