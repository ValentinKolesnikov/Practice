var employeeList = document.getElementById("employeeList");
var branchList = document.getElementById("branchList");
var servicesDirectoryList = document.getElementById("servicesDirectoryList");

if (branchList.selectedIndex == null )
    document.getElementById('branchList').options[0].setAttribute("selected", "");

document.getElementById('branchList').options[0].setAttribute("disabled", "");



function Undisable() {
    var formData = new FormData(document.forms.person);
    formData.append("id", document.getElementById("branchList").options[document.getElementById("branchList").selectedIndex].value);
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/serviceshistory/GetInfo', true);
    xhr.send(formData);
    var checkstatus = setInterval(function () {
        if (xhr.status == 200) {
            document.getElementById('employeeList').innerHTML = "<option disabled selected> Список сотрудников </option>";
            document.getElementById('servicesDirectoryList').innerHTML = "<option disabled selected> Список услуг </option>";
            clearInterval(checkstatus);
            employeeList.removeAttribute("disabled");
            servicesDirectoryList.removeAttribute("disabled");
            var arr = JSON.parse(xhr.responseText);
            for (var key in arr[0]) {
                employeeList.innerHTML += "<option value=" + arr[0][key]["Id"] + " > " + arr[0][key]["SecondName"] + " " + arr[0][key]["FirstName"][0] + ". " + arr[0][key]["MiddleName"][0] + ".</option>";
            }
            for (var key in arr[1]) {
                servicesDirectoryList.innerHTML += "<option value=" + arr[1][key]["Id"] + " > " + arr[1][key]["Name"] + "</option>";
            }
        }
        else if (xhr.status != 0) {
            clearInterval(checkstatus);
        }
    }, 30);

}


function OnSuccess(data) {
    var results = $('#results'); // получаем нужный элемент
    results.empty(); //очищаем элемент
    for (var i = 0; i < data.length; i++) {
        results.append('<li>' + data[i].Name + '</li>'); // добавляем данные в список
    }
}