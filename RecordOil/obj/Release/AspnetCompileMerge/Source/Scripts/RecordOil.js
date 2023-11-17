//-------Добавление организации--------------//
function AddOrganiz() {
    $.ajax({
        url: "/Home/AddOrganiz/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления организации----------//
function OrganizSave() {

    var isValid = true;
    if ($('#NaimenovanieOrg').val() == "") {
        $('#NaimenovanieOrg').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieOrg').css('border-color', 'lightgrey');
    }

    if ($('#PriznakOrg').val() == "") {
        $('#PriznakOrg').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PriznakOrg').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NaimenovanieOrg': $('#NaimenovanieOrg').val(),
        'PriznakOrg': $('#PriznakOrg').val(),
        'UserOrg': $('#UserOrg').val(),
        'DateOrg': $('#DateOrg').val()

    };

    $.ajax({
        url: "/Home/OrganizSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление организации//

function DeleteOrganiz(ID) {
    $.ajax({
        url: "/Home/DeleteOrganiz/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления организации //
function DeleteOrganizOK(ID) {


    $.ajax({
        url: "/Home/DeleteOrganizOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование организации//

function OrganizEdit(ID) {
    $.ajax({
        url: "/Home/OrganizEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования организации//

function OrganizEditSave() {

    var isValid = true;

    if ($('#NaimenovanieOrgEdit').val() == "") {
        $('#NaimenovanieOrgEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieOrgEdit').css('border-color', 'lightgrey');
    }

    if ($('#PriznakOrgEdit').val() == "") {
        $('#PriznakOrgEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PriznakOrgEdit').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'NaimenovanieOrgEdit': $('#NaimenovanieOrgEdit').val(),
        'PriznakOrgEdit': $('#PriznakOrgEdit').val(),
        'UserOrgEdit': $('#UserOrgEdit').val(),
        'DateOrgEdit': $('#DateOrgEdit').val(),

    };

    $.ajax({
        url: "/Home/OrganizEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----------------------ПОЛЬЗОВАТЕЛИ----------------------------
//-------Добавление пользователя--------------//
function AddUsers() {
    $.ajax({
        url: "/Home/AddUsers/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSave() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idFil').val() == "") {
        $('#idFil').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idFil').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idFil': $('#idFil').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//--------------Добавление пользователей филиалов------------------------------------------------------------------------------------------
//-------Добавление пользователя--------------//
function AddUsersGomel() {
    $.ajax({
        url: "/Home/AddUsersGomel/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSaveGomel() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }
        
    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSaveGomel",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление пользователя Мозырь--------------//
function AddUsersMozyr() {
    $.ajax({
        url: "/Home/AddUsersMozyr/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSaveMozyr() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSaveMozyr",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление пользователя ПИнск--------------//
function AddUsersPinsk() {
    $.ajax({
        url: "/Home/AddUsersPinsk/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSavePinsk() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSavePinsk",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление пользователя Туров-------------//
function AddUsersTurov() {
    $.ajax({
        url: "/Home/AddUsersTurov/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSaveTurov() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSaveTurov",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление пользователя Кобрин--------------//
function AddUsersKobrin() {
    $.ajax({
        url: "/Home/AddUsersKobrin/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSaveKobrin() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSaveKobrin",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление пользователя ЦБПО--------------//
function AddUsersCBPO() {
    $.ajax({
        url: "/Home/AddUsersCBPO/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSaveCBPO() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSaveCBPO",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление пользователя НОвополоцк--------------//
function AddUsersNovopolock() {
    $.ajax({
        url: "/Home/AddUsersNovopolock/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления пользователя----------//
function UsersSaveNovopolock() {

    var isValid = true;

    if ($('#LastName').val() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#MiddleName').val() == "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }

    if ($('#idDolj').val() == "") {
        $('#idDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDolj').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'LastName': $('#LastName').val(),
        'FirstName': $('#FirstName').val(),
        'MiddleName': $('#MiddleName').val(),
        'idDolj': $('#idDolj').val(),
        'PhoneU': $('#PhoneU').val(),
        'UserUs': $('#UserUs').val(),
        'DateUs': $('#DateUs').val()

    };

    $.ajax({
        url: "/Home/UsersSaveNovopolock",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-----------------------------------------------------------------------------------------------------------------------------------------

// Удаление пользователя//

function DeleteUsers(ID) {
    $.ajax({
        url: "/Home/DeleteUsers/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления пользователя //
function DeleteUsersOK(ID) {


    $.ajax({
        url: "/Home/DeleteUsersOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование пользователя//

function UsersEdit(ID) {
    $.ajax({
        url: "/Home/UsersEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования пользователя//

function UsersEditSave() {

    var isValid = true;

    if ($('#LastNameEdit').val() == "") {
        $('#LastNameEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastNameEdit').css('border-color', 'lightgrey');
    }

    if ($('#FirstNameEdit').val() == "") {
        $('#FirstNameEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstNameEdit').css('border-color', 'lightgrey');
    }

    if ($('#MiddleNameEdit').val() == "") {
        $('#MiddleNameEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleNameEdit').css('border-color', 'lightgrey');
    }

    if ($('#idFilEdit').val() == "") {
        $('#idFilEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idFilEdit').css('border-color', 'lightgrey');
    }

    if ($('#idDoljEdit').val() == "") {
        $('#idDoljEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idDoljEdit').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    //------RadioButton используется или нет----------------------------------------------------
    var chek1;
    var col = $('input[type="radio"]:checked').attr('id');
    {
        if (col == '0') {
            chek1 = '0';
        }
        if (col == '1') {
            chek1 = '1';
        }

        //--------------------------------------------------------
        //------------------------------------------------
        if (rules.checked) { chek1 = '1'; }
        else { chek1 = '0'; }
        //-----------------------------------------------
    }
    

    var data = {

        'ID': $('#ID').val(),
        'LastNameEdit': $('#LastNameEdit').val(),
        'FirstNameEdit': $('#FirstNameEdit').val(),
        'MiddleNameEdit': $('#MiddleNameEdit').val(),
        'idFilEdit': $('#idFilEdit').val(),
        'idDoljEdit': $('#idDoljEdit').val(),
        'PhoneUE': $('#PhoneUE').val(),
        'PriznakU': chek1,
        'UserUsEdit': $('#UserUsEdit').val(),
        'DateUsEdit': $('#DateUsEdit').val(),

    };

    $.ajax({
        url: "/Home/UsersEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//---------должности----------------------------------------------
//-------Добавление должности--------------//
function AddDolj() {
    $.ajax({
        url: "/Home/AddDolj/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления должности----------//
function DoljSave() {

    var isValid = true;
    if ($('#NaimenovanieDolj').val() == "") {
        $('#NaimenovanieDolj').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieDolj').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NaimenovanieDolj': $('#NaimenovanieDolj').val(),
        'UserDolj': $('#UserDolj').val(),
        'DateDolj': $('#DateDolj').val()

    };

    $.ajax({
        url: "/Home/DoljSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление должности//

function DeleteDolj(ID) {
    $.ajax({
        url: "/Home/DeleteDolj/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления должности //
function DeleteDoljOK(ID) {


    $.ajax({
        url: "/Home/DeleteDoljOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование должности//

function DoljEdit(ID) {
    $.ajax({
        url: "/Home/DoljEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования должности//

function DoljEditSave() {

    var isValid = true;

    if ($('#NaimenovanieDoljEdit').val() == "") {
        $('#NaimenovanieDoljEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieDoljEdit').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'NaimenovanieDoljEdit': $('#NaimenovanieDoljEdit').val(),
        'UserDoljEdit': $('#UserDoljEdit').val(),
        'DateDoljEdit': $('#DateDoljEdit').val(),

    };

    $.ajax({
        url: "/Home/DoljEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//---------Нефтепродукты----------------------------------------------
//-------Добавление нефтепродукта--------------//
function AddNefteprod() {
    $.ajax({
        url: "/Home/AddNefteprod/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления нефтепродукта----------//
function NefteprodSave() {

    var isValid = true;

    if ($('#NaimenovanieNeft').val() == "") {
        $('#NaimenovanieNeft').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieNeft').css('border-color', 'lightgrey');
    }

    if ($('#PNeft').val() == "") {
        $('#PNeft').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PNeft').css('border-color', 'lightgrey');
    }

    if ($('PrimNeft').val() == "") {
        $('#PrimNeft').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PrimNeft').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NaimenovanieNeft': $('#NaimenovanieNeft').val(),
        'PNeft': $('#PNeft').val(),
        'PrimNeft': $('#PrimNeft').val(),
        'UserNeft': $('#UserNeft').val(),
        'DateNeft': $('#DateNeft').val()

    };

    $.ajax({
        url: "/Home/NefteprodSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление нефтепродукта//

function DeleteNeft(ID) {
    $.ajax({
        url: "/Home/DeleteNeft/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления нефтепродукта //
function DeleteNeftOK(ID) {


    $.ajax({
        url: "/Home/DeleteNeftOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование нефтепродукта//

function NeftEdit(ID) {
    $.ajax({
        url: "/Home/NeftEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования нефтепродукта//

function NeftEditSave() {
    var chek;
    var isValid = true;

    if ($('#NaimenovanieNeftEdit').val() == "") {
        $('#NaimenovanieNeftEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieNeftEdit').css('border-color', 'lightgrey');
    }

    if ($('#PNeftEdit').val() == "") {
        $('#PNeftEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PNeftEdit').css('border-color', 'lightgrey');
    }

    if ($('#PrimNeftEdit').val() == "") {
        $('#PrimNeftEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PrimNeftEdit').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }
    //------RadioButton используется или нет----------------------------------------------------
    var col = $('input[type="radio"]:checked').attr('id');
    {
        if (col == '0') {
            chek = '0';
        }
        if (col == '1') {
            chek = '1';
        }

        //--------------------------------------------------------
        //------------------------------------------------
        if (rules.checked)
        { chek = '1'; }
        else
        { chek = '0'; }
        //-----------------------------------------------


        var data = {

            'ID': $('#ID').val(),
            'NaimenovanieNeftEdit': $('#NaimenovanieNeftEdit').val(),
            'PNeftEdit': $('#PNeftEdit').val(),
            'PrimNeftEdit': $('#PrimNeftEdit').val(),
            'PriznakNeftEdit': chek,
            'UserNeftEdit': $('#UserNeftEdit').val(),
            'DateNeftEdit': $('#DateNeftEdit').val(),
        };

        $.ajax({
            url: "/Home/NeftEditSave",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//----------------------Резервуары----------------------------
//-------Добавление резервуара--------------//
function AddRezer() {
    $.ajax({
        url: "/Home/AddRezer/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления резервуара----------//
function RezerSave() {

    var isValid = true;

    if ($('#NaimenovanieRez').val() == "") {
        $('#NaimenovanieRez').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieRez').css('border-color', 'lightgrey');
    }

    if ($('#VpolRez').val() == "") {
        $('#VpolRez').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VpolRez').css('border-color', 'lightgrey');
    }

    if ($('#VItogRez').val() == "") {
        $('#VItogRez').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VItogRez').css('border-color', 'lightgrey');
    }

    if ($('#idFilRez').val() == "") {
        $('#idFilRez').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idFilRez').css('border-color', 'lightgrey');
    }
        

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NaimenovanieRez': $('#NaimenovanieRez').val(),
        'VpolRez': $('#VpolRez').val(),
        'VItogRez': $('#VItogRez').val(),
        'idFilRez': $('#idFilRez').val(),
        'UserRez': $('#UserRez').val(),
        'DateRez': $('#DateRez').val()

    };

    $.ajax({
        url: "/Home/RezerSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление резервуара//

function DeleteRezer(ID) {
    $.ajax({
        url: "/Home/DeleteRezer/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления резервуара //
function DeleteRezerOK(ID) {


    $.ajax({
        url: "/Home/DeleteRezerOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование резервуара//

function RezerEdit(ID) {
    $.ajax({
        url: "/Home/RezerEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования резервуара//

function RezerEditSave() {

    var isValid = true;

    if ($('#NaimenovanieEdit').val() == "") {
        $('#NaimenovanieEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NaimenovanieEdit').css('border-color', 'lightgrey');
    }

    if ($('#VPolEdit').val() == "") {
        $('#VPolEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VPolEdit').css('border-color', 'lightgrey');
    }

    if ($('#VItogEdit').val() == "") {
        $('#VItogEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VItogEdit').css('border-color', 'lightgrey');
    }

    if ($('#idFilEdit').val() == "") {
        $('#idFilEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idFilEdit').css('border-color', 'lightgrey');
    }       

    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'NaimenovanieEdit': $('#NaimenovanieEdit').val(),
        'VPolEdit': $('#VPolEdit').val(),
        'VItogEdit': $('#VItogEdit').val(),
        'idFilEdit': $('#idFilEdit').val(),
        'UserRezEdit': $('#UserRezEdit').val(),
        'DateRezEdit': $('#DateRezEdit').val(),

    };

    $.ajax({
        url: "/Home/RezerEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//--------ДОГОВОРЫ-----------------------------------
//-------Добавление договора--------------//
function AddDogovor() {
    $.ajax({
        url: "/Home/AddDogovor/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Открытие списка с датами для заполнения договора----------//
function DogovorSave() {

    var isValid = true;

    if ($('#NumberDog').val() == "") {
        $('#NumberDog').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberDog').css('border-color', 'lightgrey');
    }

    if ($('#DateDogM').val() == "") {
        $('#DateDogM').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DateDogM').css('border-color', 'lightgrey');
    }

    if ($('#S').val() == "") {
        $('#S').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#S').css('border-color', 'lightgrey');
    }

    if ($('#Po').val() == "") {
        $('#Po').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Po').css('border-color', 'lightgrey');
    }

    if ($('#OrganizDog').val() == "") {
        $('#OrganizDog').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#OrganizDog').css('border-color', 'lightgrey');
    }
        


    if (isValid == false) {
        return false;
    }

    var data = {
        
        'NumberDog': $('#NumberDog').val(),
        'DateDogM': $('#DateDogM').val(),
        'S': $('#S').val(),
        'Po': $('#Po').val(),
        'OrganizDog': $('#OrganizDog').val(),
        'PrimDog': $('#PrimDog').val(),
        'UserDog': $('#UserDog').val(),
        'DateDog': $('#DateDog').val()

    };

    $.ajax({
        url: "/Home/DogovorSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#tabdog').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
// Удаление договора//

function DeleteDogovor(ID) {
    $.ajax({
        url: "/Home/DeleteDogovor/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления договора //
function DeleteDogovorOK(ID) {


    $.ajax({
        url: "/Home/DeleteDogovorOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование договора//

function DogovorEdit(ID) {
    $.ajax({
        url: "/Home/DogovorEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования договора//

function DogovorEditSave() {

    var isValid = true;

    if ($('#OrganizDogE').val() == "") {
        $('#OrganizDogE').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#OrganizDogE').css('border-color', 'lightgrey');
    }

    if ($('#NumberDogE').val() == "") {
        $('#NumberDogE').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberDogE').css('border-color', 'lightgrey');
    }

    if ($('#DateDogME').val() == "") {
        $('#DateDogME').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DateDogME').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var dd = [];

    for (var it = 1; it <= tabtab.rows.length; it++) {
        var d =
        {
            'IdTd': $('#IdTD_' + Number(it)).val(),
            'DateDog': $('#DateDogE_' + Number(it)).val(),
            'IdNeft': $('#NeftDogE_' + Number(it)).val(),
            'Massa': $('#MassaDogE_' + Number(it)).val(),
            'Primech': $('#PrimechDogE_' + Number(it)).val()
        };
        if (d.IdTd != undefined) {
            var employee = JSON.stringify(d);

            dd.push(d);
        }
    }

    var data = {
            'ID': $('#ID').val(),
            'NumberDogE': $('#NumberDogE').val(),
            'DateDogME': $('#DateDogME').val(),
            'OrganizDogE': $('#OrganizDogE').val(),
            'PrimDogE': $('#PrimDogE').val(),
            'UserDogE': $('#UserDogE').val(),
            'DateDogE': $('#DateDogE').val(),
            'TabDogE': dd


        };

        $.ajax({
            url: "/Home/DogovorEditSave",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }

    //---------------------------------------------------
    //-------Запись в БД договора и данных по месяцам в договоре----------//
    function DogovorSaveOk() {

        var tabletab = document.getElementById('tabb');

        var isValid = true;

        for (var i = 1; i <= tabletab.rows.length; i++) {

            if (($('#Massa_' + Number(i)).val() == "")) {
                $('#Massa_' + Number(i)).css('border-color', 'Red');
                isValid = false;
            }
            else {
                $('#Massa_' + Number(i)).css('border-color', 'lightgrey');

            }
        }

        if (isValid == false) {
            return false;
        }

        var dd = [];

        for (var it = 1; it <= tabletab.rows.length; it++) {
            var d =
            {
                'dateDog': $('#dateM_' + Number(it)).val(),
                'IdNeft': $('#Neftprod_' + Number(it)).val(),
                'Massa': $('#Massa_' + Number(it)).val(),
                'Primech': $('#PrimDog_' + Number(it)).val()
            };
            if (d.dateDog != undefined) {
                var employee = JSON.stringify(d);

                dd.push(d);
            }

        }


        var data = {
            'NumberDog': $('#NumberDog').val(),
            'DateDogM': $('#DateDogM').val(),
            'OrganizDog': $('#OrganizDog').val(),
            'PrimDog': $('#PrimDog').val(),
            'UserDog': $('#UserDog').val(),
            'DateDog': $('#DateDog').val(),
            'TabDog': dd


        };

        $.ajax({
            url: "/Home/DogovorSaveOk",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
//----------------ЗАЯВКИ--------------------------------
//-------Добавление заявки--------------//
function AddZay() {
    $.ajax({
        url: "/Home/AddZay/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent1').html(result);
            $('#ServicesModal1').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления заявки----------//
function ZaySave() {
        
    var tList = document.getElementById('ListT');
    var dZay = [];
    for (var it = 1; it <= tList.rows.length; it++) {
        var d =
        {
            'NeftZay': $('#NeftProd_' + Number(it)).val(),
            'Massa': $('#MassaPlan_' + Number(it)).val(),
            'IdSklad': $('#sk_' + Number(it)).val()
        };

        if (d.NeftZay != undefined) {
            var employee = JSON.stringify(d);
            dZay.push(d);
        }
        
            /*dZay.push(d);*/
        
    }
        var data = {
            'IDF': $('#IDF').val(),
            'NumberZay': $('#NumberZay').val(),
            'DateZay': $('#DateZay').val(),
            'UserFil': $('#UserFil').val(),
            'DatePlan': $('#DatePlan').val(),
            'UserZayModif': $('#UserZayModof').val(),
            'DateZayModif': $('#DateZayModif').val(),
            'TabZay': dZay
        };

        $.ajax({
            url: "/Home/ZaySave",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                //$('#ServicesModalContent3').html(result);
                //$('#ServicesModal3').modal('show');
                $('#ListRez').html(result);
                //$('#ListRez').modal('show');
               
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}

//-------Сохранение добавления заявки----------//
function SoglasZay() {
    var data = {
        'ID': $('#ID').val(),
        'UserZayE': $('#UserZayE').val(),
        'DateZayE': $('#DateZayE').val(),
               };
$.ajax({
    url: "/Home/SoglasZay",
    type: "POST",
    contentType: "application/json;charset=UTF-8",
    data: JSON.stringify(data),
    dataType: "html",
    success: function (result) {
        $('#ServicesModalContent1').html(result);
        //    $('#ServicesModal1').modal('show');
    },
    error: function (errormessage) {
        alert(errormessage.responseText);
    }
});
    
}



//-------Сохранение добавления заявки----------//
//function ZaySave() {

//    var tList = document.getElementById('ListT');
//    var dZay = [];
//    for (var it = 1; it <= tList.rows.length; it++) {
//        var d =
//        {
//            'NeftZay': $('#NeftProd_' + Number(it)).val(),
//            'Massa': $('#MassaPlan_' + Number(it)).val(),
//            'IdSklad': $('#sk_' + Number(it)).val()
//        };

//        if (d.NeftZay != undefined) {
//            var employee = JSON.stringify(d);
//            dZay.push(d);
//        }

//        /*dZay.push(d);*/

//    }
//    var data = {
//        'IDF': $('#IDF').val(),
//        'NumberZay': $('#NumberZay').val(),
//        'DateZay': $('#DateZay').val(),
//        'UserFil': $('#UserFil').val(),
//        'DatePlan': $('#DatePlan').val(),
//        'UserZayModif': $('#UserZayModof').val(),
//        'DateZayModif': $('#DateZayModif').val(),
//        'TabZay': dZay
//    };

//    $.ajax({
//        url: "/Home/ZaySave",
//        type: "POST",
//        contentType: "application/json;charset=UTF-8",
//        data: JSON.stringify(data),
//        dataType: "html",
//        success: function (result) {
//            //$('#ServicesModalContent3').html(result);
//            //$('#ServicesModal3').modal('show');
//            $('#ListRez').html(result);
//            //$('#ListRez').modal('show');

//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}
//------------------------------------------------------------------
//-------Сохранение добавления нулевой заявки----------//
function ZaySaveZero() {

    var isValid = true;

    if ($('#NumberZay').val() == "") {
        $('#NumberZay').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberZay').css('border-color', 'lightgrey');
    }


    if ($('#DatePlan').val() == "") {
        $('#DatePlan').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Dateplan').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }
    
    var data = {
        'IDF': $('#IDF').val(),
        'NumberZay': $('#NumberZay').val(),
        'DateZay': $('#DateZay').val(),
        'UserFil': $('#UserFil').val(),
        'DatePlan': $('#DatePlan').val(),
        'UserZayModif': $('#UserZayModof').val(),
        'DateZayModif': $('#DateZayModif').val(),
        };

    $.ajax({
        url: "/Home/ZaySaveZero",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            //$('#ServicesModalContent3').html(result);
            //$('#ServicesModal3').modal('show');
            $('#ListRez').html(result);
            //$('#ListRez').modal('show');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//------------------------------------------------------------------

//Редактирование заявки//

function ZayavkaEdit(ID) {
    $.ajax({
        url: "/Home/ZayavkaEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent1').html(result);
            $('#ServicesModal1').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования заявки//

function ZayavkaEditSave() {

    var isValid = true;

    for (var i = 1; i <= tabtab.rows.length; i++) {

      
        if (($('#MassaZayE_' + Number(i)).val() == "")) {
            $('#MassaZayE_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#MassaZayE_' + Number(i)).css('border-color', 'lightgrey');
        }

        if (($('#PlanZayE_' + Number(i)).val() == "")) {
            $('#PlanZayE_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#PlanZayE_' + Number(i)).css('border-color', 'lightgrey');
        }
        if (isValid == false) {
            return false;
        }
    }

    if (isValid == false) {
        return false;
    }
       
    var ddd = [];

    for (var it = 1; it <= tabtab.rows.length; it++) {
        var d =
        {
            'IdZay': $('#IdTZ_' + Number(it)).val(),            
            'NeftZay': $('#NeftZayE_' + Number(it)).val(),
            'Massa': $('#MassaZayE_' + Number(it)).val(),
            'Plan': $('#PlanZayE_' + Number(it)).val(),
            'Prich': $('#PrimechZayE_' + Number(it)).val(),
        };
        //if (d.IdTd != undefined) {
        //    var employee = JSON.stringify(d);
        //    ddd.push(d);
        //}
        console.log("massa ="  +  $('#MassaZayE_' + Number(it)).val());
        ddd.push(d);
    }

    var data = {
        'ID': $('#ID').val(),
        'NumberDogE': $('#NumberDogE').val(),
        'DateDogME': $('#DateDogME').val(),
        'OrganizDogE': $('#OrganizDogE').val(),
        'PrimDogE': $('#PrimDogE').val(),
        'UserZayE': $('#UserZayE').val(),
        'DateZayE': $('#DateZayE').val(),
        'TabZayE': ddd
    };

    $.ajax({
        url: "/Home/ZayavkaEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent1').html(result);
        //    $('#ServicesModal1').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Удаление заявки//

function DeleteZayavka(ID) {
    $.ajax({
        url: "/Home/DeleteZayavka/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления заявки //
function DeleteZayavkaOK(ID) {


    $.ajax({
        url: "/Home/DeleteZayavkaOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//

// Удаление заявки//

function DeleteZayavkaAll(ID) {
    $.ajax({
        url: "/Home/DeleteZayavkaAll/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления заявки //
function DeleteZayavkaAllOK(ID) {


    $.ajax({
        url: "/Home/DeleteZayavkaAllOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//

// Закрытие заявок//

function ClosedMonth() {
    $.ajax({
        url: "/Home/ClosedMonth/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение закрытия заявок //
function ClosedZayavkaOK(ID) {


    $.ajax({
        url: "/Home/ClosedZayavkaOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----------Отчет в PDF ------------------------------------------------
function Report() {
    //var stringhref = "Report?";

    //stringhref += "dat=" + $('#datapicker1').val() + "&" + "location=" + $('#LocID_1').val(); /*+ "&" + "IDPodrPr=" + $('#pppp').val() + "&" + "IDPodrOtd=" + $('#otdel').val() + "&" + "IDPodrPodr=" + $('#gruppa').val() + "&" + "IDPodrUch=" + $('#uch').val();*/
    //window.location = stringhref;
    window.location = "/Home/Report/";
}

//Работаем с новым алгоритмом заявок!!!!!!!!!!!!!!!!!!!!
function LetRes() {

    var isValid = true;

    if ($('#NumberZay').val() == "") {
        $('#NumberZay').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberZay').css('border-color', 'lightgrey');
    }
        

    if ($('#DatePlan').val() == "") {
        $('#DatePlan').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Dateplan').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        'Fill': $('#IDF').val(),
        'DatePlan': $('#DatePlan').val(),
        'UserNeft': $('#UserNeft').val(),
        'DateNeft': $('#DateNeft').val()

    };

    $.ajax({
        url: "/Home/LetRes",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ListRez').html(result);
            //$('#ListRez').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-Выводим остатки и открываем поля для заполнения заявки-//
function OstatAdd() {

    var tabletab = document.getElementById('ListT');

    var isValid = true;

    for (var i = 1; i <= tabletab.rows.length; i++) {

        if (($('#ListM_' + Number(i)).val() == "")) {
            $('#ListM_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#ListM_' + Number(i)).css('border-color', 'lightgrey');
        }

        if (($('#ListN_' + Number(i)).val() == "")) {
            $('#ListN_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#ListN_' + Number(i)).css('border-color', 'lightgrey');
        }
    }

    if (isValid == false) {
        return false;
    }

    var dd = [];

    for (var it = 1; it <= tabletab.rows.length; it++) {
        var d =
        {
            'Plan': $('#ListR_' + Number(it)).val(),
            'NeftZay': $('#ListN_' + Number(it)).val(),
            'Massa': $('#ListM_' + Number(it)).val(),            
        };
        if (d.Plan != undefined) {
            var employee = JSON.stringify(d);
            dd.push(d);
        }
       
    }

    var data = {
        'Date': $('#DatePlan').val(),
        'UserDog': $('#UserZayModof').val(),
        'DateDog': $('#DateZayModif').val(),
        'TabList': dd
    };

    $.ajax({
        url: "/Home/OstatAdd",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//------------------------------------------------------------------------------------------------//
//----------------------Склады----------------------------
//-------Добавление склада--------------//
function AddSklad() {
    $.ajax({
        url: "/Home/AddSklad/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSave() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }       

    if ($('#idFilS').val() == "") {
        $('#idFilS').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idFilS').css('border-color', 'lightgrey');
    }       

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'idFilS': $('#idFilS').val(),        
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//------------------------------------------------------------------------------------------------------------------------------------
//-------Добавление склада АУ--------------//
function AddSkladAU() {
    $.ajax({
        url: "/Home/AddSkladAU/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада АУ----------//
function SkladSaveAU() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveAU",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//--------------------------------//

//-------Добавление склада Гомель--------------//
function AddSkladGomel() {
    $.ajax({
        url: "/Home/AddSkladGomel/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSaveGomel() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }
        

    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveGomel",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//--------------------------------//
//-------Добавление склада Мозырь--------------//
function AddSkladMozyr() {
    $.ajax({
        url: "/Home/AddSkladMozyr/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSaveMozyr() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveMozyr",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление склада Пинск--------------//
function AddSkladPinsk() {
    $.ajax({
        url: "/Home/AddSkladPinsk/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSavePinsk() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSavePinsk",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление склада--------------//
function AddSkladTurov() {
    $.ajax({
        url: "/Home/AddSkladTurov/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада Туров----------//
function SkladSaveTurov() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }

    
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveTurov",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление склада Кобрин--------------//
function AddSkladKobrin() {
    $.ajax({
        url: "/Home/AddSkladKobrin/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSaveKobrin() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }

    
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveKobrin",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление склада ЦБПО--------------//
function AddSkladCBPO() {
    $.ajax({
        url: "/Home/AddSkladCBPO/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSaveCBPO() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'idFilS': $('#idFilS').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveCBPO",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление склада Новополоцк--------------//
function AddSkladNovopolock() {
    $.ajax({
        url: "/Home/AddSkladNovopolock/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления склада----------//
function SkladSaveNovopolock() {

    var isValid = true;

    if ($('#NameSklad').val() == "") {
        $('#NameSklad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSklad').css('border-color', 'lightgrey');
    }
        
    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'NameSklad': $('#NameSklad').val(),
        'UserSklad': $('#UserSklad').val(),
        'DateSklad': $('#DateSklad').val()
    };

    $.ajax({
        url: "/Home/SkladSaveNovopolock",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//------------------------------------------------------------------------------------------------------------------------------------
// Удаление склада//

function DeleteSklad(ID) {
    $.ajax({
        url: "/Home/DeleteSklad/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления склада//
function DeleteSkladOK(ID) {


    $.ajax({
        url: "/Home/DeleteSkladOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование склада//

function SkladEdit(ID) {
    $.ajax({
        url: "/Home/SkladEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования склада//

function SkladEditSave() {

    var isValid = true;

    if ($('#NameSkladEdit').val() == "") {
        $('#NameSkladEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NameSkladEdit').css('border-color', 'lightgrey');
    }
        

    if ($('#idFilSkladEdit').val() == "") {
        $('#idFilSkladEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#idFilSkladEdit').css('border-color', 'lightgrey');
    }
        

    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'NameSkladEdit': $('#NameSkladEdit').val(),
        'idFilSkladEdit': $('#idFilSkladEdit').val(),
        'UserSkladEdit': $('#UserSkladEdit').val(),
        'DateSkladEdit': $('#DateSkladEdit').val(),

    };

    $.ajax({
        url: "/Home/SkladEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//---Добавление остатков---//

function AddOstatki(IDF, Po) {
    let val = document.getElementById("IDF").value;
       $.ajax({        
        url: "/Home/AddOstatki?idf=" + val + "&" + "DatP=" + $('#Po').val(),
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления остатков----------//
function OstatkiSave() {

    var isValid = true;

    if (($('#DPlan').val() == "")) {
        $('#DPlan').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DPlan').css('border-color', 'lightgrey');
    }

    //for (var i = 1; i <= tab1.rows.length; i++) {


    //    if (($('#MassOst_' + Number(i)).val() == "")) {
    //         $('#MassOst_' + Number(i)).css('border-color', 'Red');
    //        isValid = false;
    //    }
    //    else {
    //        $('#MasOst_' + Number(i)).css('border-color', 'lightgrey');
    //    }
                
    //    if (isValid == false) {
    //        return false;
    //    }
    //}

    if (isValid == false) {
        return false;
    }

    var ddd = [];

    for (var it = 1; it <= tab1.rows.length; it++) {
        if ($('#IdOst_' + Number(it)).val() != null)
        {
            var d =
            {
                'Date': $('#DPlan').val(),
                'Mass': $('#MassOst_' + Number(it)).val(),
                'IdNeft': $('#IdNeftOst_' + Number(it)).val(),
                'IdSklad': $('#IdOst_' + Number(it)).val(),
                'Prim': $('#PrimOst_' + Number(it)).val(),
                'UserM': $('#UserMod').val(),
                'DateM': $('#DMod').val(),
            };
            //if (d.IdTd != undefined) {
            //    var employee = JSON.stringify(d);
            //    ddd.push(d);
            //}   
            if (d.Mass != 0) {

                 ddd.push(d);
            }
            
        }
    }

    var data = {
        'ID': $('#ID').val(),        
        'TabOstat': ddd


    };


    $.ajax({
        url: "/Home/OstatkiSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//--------------------------------//
// Удаление остатков//

function DeleteOstatki(ID) {
    $.ajax({
        url: "/Home/DeleteOstatki/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления остатков//
function DeleteOstatkiOK(ID) {


    $.ajax({
        url: "/Home/DeleteOstatkiOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----Редактирование остатков-------------------//
function OstatkiEdit(ID) {
    $.ajax({
        url: "/Home/OstatkiEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования остатка//

function OstatkiEditSave() {

    var isValid = true;

    if ($('#MassaOstatEdit').val() == "") {
        $('#MassaOstatEdit').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MassaOstatEdit').css('border-color', 'lightgrey');
    }
        

    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'MassaOstatEdit': $('#MassaOstatEdit').val(),
        'PrimOstatEdit': $('#PrimOstatEdit').val(),
        'UserOstEdit': $('#UserOstEdit').val(),
        'DateOstEdit': $('#DateOstEdit').val(),
        'DOstEdit': $('#DOstEdit').val(),
        'idSkladE': $('#idSkladE').val(),

    };

    $.ajax({
        url: "/Home/OstatkiEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//------------------------------------------------------
//----------Отчет в PDF ------------------------------------------------
function ReportTEST() {

    var isValid = true;

    if ($('#S').val() == "") {
        $('#S').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#S').css('border-color', 'lightgrey');
    }
    if ($('#Po').val() == "") {
        $('#Po').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Po').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var stringhref = "/Home/ReportTEST?"; 
                
    $.ajax({
        url: "/Home/PrintReport",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function Rep(result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
            stringhref += "IDF=" + $('#IDF').val() + "&" + "S=" + $('#S').val() + "&" + "Po=" + $('#Po').val()
            window.location = stringhref;
            setTimeout(function () {
                $("#ServicesModal").modal('hide');
            }, 3000);
        },        
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });    
}


//--------------------------------------
// Нажатие вкладки Справка в модальном окне //

function Reference(ID) {
    $.ajax({
        url: "/Home/Reference/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//----------Отчет в docx Заявка нефтепродуктов ------------------------------------------------
function PrintZayWord() {
    
    var stringhref1 = "/Home/PrintZayWord?";
    stringhref1 += "ID=" + $('#ID').val();
    window.location = stringhref1;    
}

//----------------------------------------------------------------------------------------------
function GetOstatTab() {
        
    var data = {
        //'ID': ID,
        'IDF': $('#IDF').val(),
        'S': $('#S').val(),
        'Po': $('#Po').val()        
    };
    var x = document.getElementById("loadImg");
    x.style.display = "block";
    $.ajax({
        url: "/Home/GetOstatTab/",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (data) {
            //$('#search').replaceWith(data);
            x.style.display = "none";
            $('#TabOstatki').hide();
            $('#TabOstatki').html(data).animate({ opacity: 'show' }, "slow");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    }
//--------------------------------//
//-------Добавление логина и пароля--------------//
function AddLoginPassword() {
    $.ajax({
        url: "/Home/AddLoginPassword/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления логина и пароля----------//
function LoginPasswordSave() {

    var RT = document.getElementById('RT');

    var isValid = true;

    if ($('#Logi').val() == "") {
        $('#Logi').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Logi').css('border-color', 'lightgrey');
    }

    if ($('#Passw').val() == "") {
        $('#Passw').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Passw').css('border-color', 'lightgrey');
    }
        

    if (isValid == false) {
        return false;
    }

    
    //-------------------------------------------------------------------------------
    var selected = []
    var checkboxes = document.querySelectorAll('input[name=inList]:checked');

    for (var i = 0; i < checkboxes.length; i++) {
        selected.push(checkboxes[i].value);
    }
    //--------------------------------------------------------------------------------
    var f = $('#idUS');
    var data = {
        'Login': $('#Logi').val(),
        'Password': $('#Passw').val(),
        'idUS': $('#idUS').val(),
        'UserLog': $('#UserLog').val(),
        'DateLog': $('#DateLog').val(),

        'dd': selected
    };
    
    $.ajax({
        url: "/Home/LoginPasswordSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//--------------------------------//
//-------Получаем список заявок в зависимости от дат---------------------------------------------------------------------------------------
function GetZayTab() {

    var data = {        
        'IDF': $('#IDF').val(),
        'SZ': $('#SZ').val(),
        'PoZ': $('#PoZ').val(),
        'SZM': $('#SZM').val(),
        'PoZM': $('#PoZM').val()
    };
    var x = document.getElementById("loadImgZ");
    console.log(x);
    x.style.display = "block";
    $.ajax({
        url: "/Home/GetZayTab/",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (data) {
            //$('#search').replaceWith(data);
            x.style.display = "none";
            $('#TableZay').hide();
            $('#TableZay').html(data).animate({ opacity: 'show' }, "slow");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----Печать списка заявок----------------------------//
function PrintZayList() {

    var isValid = true;

    if ($('#SZ').val() == "") {
        $('#SZ').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SZ').css('border-color', 'lightgrey');
    }

    if ($('#PoZ').val() == "") {
        $('#PoZ').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PoZ').css('border-color', 'lightgrey');
    }

    if ($('#SZM').val() == "") {
        $('#SZM').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SZM').css('border-color', 'lightgrey');
    }

    if ($('#PoZM').val() == "") {
        $('#PoZM').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PoZM').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var stringhref = "/Home/PrintZayList?";

    $.ajax({
        url: "/Home/PrintReport",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function Rep(result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
            stringhref += "IDF=" + $('#IDF').val() + "&" + "SZ=" + $('#SZ').val() + "&" + "PoZ=" + $('#PoZ').val() + "&" + "SZM=" + $('#SZM').val() + "&" + "PoZM=" + $('#PoZM').val()
            window.location = stringhref;
            setTimeout(function () {
                $("#ServicesModal").modal('hide');
            }, 3000);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----------------------------------------------------//
//----------------СВОДНЫЕ ЗАЯВКИ--------------------------------
//-------Добавление сводной заявки--------------//
function AddTotalZay() {
    $.ajax({
        url: "/Home/AddTotalZay/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent1').html(result);
            $('#ServicesModal1').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления заявки----------//
function ZayTotalSave() {
        
    var tList = document.getElementById('ListT');
    var dZay = [];
    for (var it = 1; it <= tList.rows.length; it++) {
        var d =
        {
            
            'neftTotal': $('#IDneftTotal_' + Number(it)).val(),
            'filialTotal': $('#IDfilialTotal_' + Number(it)).val(),
            'OstTotal': $('#OstTotal_' + Number(it)).val(),
            'PotrebTotal': $('#PotrebTotal_' + Number(it)).val(),
            'DostavkaTotal': $('#DostavkaTotal_' + Number(it)).val(),
            'NalSkladTotal': $('#NalSkladITO_' + Number(it)).val(),
            'PlanVITOGTotal': $('#PlanVITO_' + Number(it)).val(),
        };

        //if ((d.NeftZay != undefined) && (d.Massa != 0)) {
        //    var employee = JSON.stringify(d);
        //    dZay.push(d);
        //}

        dZay.push(d);

    }

    var data = {
        'NumberZayTotal': $('#NumberZayTotal').val(),
        'DateZayTotal': $('#DateZayTotal').val(),
        'DatePlanTotal': $('#DatePlanTotal').val(),
        'UserTotalModific': $('#UserTotalModific').val(),
        'DateTotalModific': $('#DateTotalModific').val(),
        'TabZay': dZay
    };

    $.ajax({
        url: "/Home/ZayTotalSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent1').html(result);
            //$('#ServicesModal3').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//------------------------------------------------------------------------------
//Открываем список нефтепродуктов и филиалов для сводной заявки
function LetResTotal() {

    var isValid = true;

    if ($('#NumberZayTotal').val() == "") {
        $('#NumberZayTotal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberZayTotal').css('border-color', 'lightgrey');
    }


    if ($('#DatePlanTotal').val() == "") {
        $('#DatePlanTotal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DateplanTotal').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {       
        'DatePlanTotal': $('#DatePlanTotal').val(),
        'UserTotalModific': $('#UserTotalModific').val(),
        'DateTotalModific': $('#DateTotalModific').val()
    };

    $.ajax({
        url: "/Home/LetResTotal",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ListRezTotal').html(result);
            //$('#ListRezTotal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//---------Редактирование сводной заявки-------------------------------------

function ZayavkaTotalEdit(ID) {
    $.ajax({
        url: "/Home/ZayavkaTotalEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent1').html(result);
            $('#ServicesModal1').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования заявки//

function ZayavkaTotalEditSave() {
    var tList = document.getElementById('ListT');
    var isValid = true;

    for (var i = 1; i <= tList.rows.length; i++) {


        if (($('#PotrebTotal_' + Number(i)).val() == "")) {
            $('#PotrebTotal_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#PotrebTotal_' + Number(i)).css('border-color', 'lightgrey');
        }

        if (($('#DostavkaTotal_' + Number(i)).val() == "")) {
            $('#DostavkaTotal_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#DostavkaTotal_' + Number(i)).css('border-color', 'lightgrey');
        }
        if (isValid == false) {
            return false;
        }
    }

    if (isValid == false) {
        return false;
    }
    
    var dZay = [];
    for (var it = 1; it <= tList.rows.length; it++) {
        var d =
        {
            'ID': $('#IDzapTotal_' + Number(it)).val(),
            'neftTotal': $('#IDneftTotal_' + Number(it)).val(),
            'filialTotal': $('#IDfilialTotal_' + Number(it)).val(),
            'OstTotal': $('#OstTotal_' + Number(it)).val(),
            'PotrebTotal': $('#PotrebTotal_' + Number(it)).val(),
            'DostavkaTotal': $('#DostavkaTotal_' + Number(it)).val(),
            'NalSkladTotal': $('#NalSkladITO_' + Number(it)).val(),
            'PlanVITOGTotal': $('#PlanVITO_' + Number(it)).val(),
        };
                
        dZay.push(d);
    }

    var data = {
        'IDF': $('#IDF').val(),
        'UserTotalModific': $('#UserZayModof').val(),
        'DateTotalModific': $('#DateZayModif').val(),
        'TabZay': dZay
    };

    $.ajax({
        url: "/Home/ZayavkaTotalEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent3').html(result);
            $('#ServicesModal3').modal('show');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Удаление заявки//

function DeleteZayavkaTotal(ID) {
    $.ajax({
        url: "/Home/DeleteZayavkaTotal/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления заявки //
function DeleteZayavkaTotalOK(ID) {


    $.ajax({
        url: "/Home/DeleteZayavkaTotalOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//-------Получаем список сводных заявок в зависимости от дат---------------------------------------------------------------------------------------
function GetZayTabTotal() {

    var data = {
        'SZTotal': $('#SZTotal').val(),
        'PoZTotal': $('#PoZTotal').val(),
        'SZMTotal': $('#SZMTotal').val(),
        'PoZMTotal': $('#PoZMTotal').val()
    };
    var x = document.getElementById("loadImgZ");
    console.log(x);
    x.style.display = "block";
    $.ajax({
        url: "/Home/GetZayTabTotal/",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (data) {
            //$('#search').replaceWith(data);
            x.style.display = "none";
            $('#TableZay').hide();
            $('#TableZay').html(data).animate({ opacity: 'show' }, "slow");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//------------------Печать списка сводных заявок---------------------------------------------------
function PrintZayListTotal() {

    var isValid = true;

    if ($('#SZTotal').val() == "") {
        $('#SZTotal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SZTotal').css('border-color', 'lightgrey');
    }

    if ($('#PoZTotal').val() == "") {
        $('#PoZTotal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PoZTotal').css('border-color', 'lightgrey');
    }

    if ($('#SZMTotal').val() == "") {
        $('#SZMTotal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SZMTotal').css('border-color', 'lightgrey');
    }

    if ($('#PoZMTotal').val() == "") {
        $('#PoZMTotal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PoZMTotal').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var stringhref = "/Home/PrintZayListTotal?";

    $.ajax({
        url: "/Home/PrintReport",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function Rep(result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
            stringhref += "SZTotal=" + $('#SZTotal').val() + "&" + "PoZTotal=" + $('#PoZTotal').val() + "&" + "SZMTotal=" + $('#SZMTotal').val() + "&" + "PoZMTotal=" + $('#PoZMTotal').val()
            window.location = stringhref;
            setTimeout(function () {
                $("#ServicesModal").modal('hide');
            }, 3000);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----------------------------------------------------//
//----------Печать сводной заявки ------------------------------------------------
function PrintZayTotalWord() {
        
    var stringhref = "/Home/PrintZayTotalWord?";

    $.ajax({
        url: "/Home/PrintReport",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function Rep(result) {
            $('#ServicesModalContent3').html(result);
            $('#ServicesModal3').modal('show');
            stringhref += "IDF=" + $('#IDF').val();
            window.location = stringhref;
            setTimeout(function () {
                $("#ServicesModal3").modal('hide');
            }, 3000);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//----------------------------------------------------//
//-------Получаем список заявок в зависимости от дат b филиала---------------------------------------------------------------------------------------
function GetZayTotalTab() {

    var data = {
        'IDOrg': $('#IdOrgan').val(),
        'SZ': $('#SZ').val(),
        'PoZ': $('#PoZ').val(),
        'SZM': $('#SZM').val(),
        'PoZM': $('#PoZM').val()
    };
    var x = document.getElementById("loadImgZ");
    console.log(x);
    x.style.display = "block";
    $.ajax({
        url: "/Home/GetZayTotalTab/",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (data) {
            //$('#search').replaceWith(data);
            x.style.display = "none";
            $('#TableZay').hide();
            $('#TableZay').html(data).animate({ opacity: 'show' }, "slow");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Удаление логина пользователя//

function DeleteLogin(ID) {
    $.ajax({
        url: "/Home/DeleteLogin/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
            $('#ServicesModalDelete').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
//Подтверждение удаления логина пользователя //
function DeleteLoginOK(ID) {

    $.ajax({
        url: "/Home/DeleteLoginOK/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalDeleteContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//-----------------------------//
// Редактирование логина//

function LoginEdit(ID) {
    $.ajax({
        url: "/Home/LoginEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования логина и пароля//

function LoginEditSave() {
    var RT = document.getElementById('RT');
    var isValid = true;

    if ($('#Logi').val() == "") {
        $('#Logi').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Logi').css('border-color', 'lightgrey');
    }

    if ($('#Passw').val() == "") {
        $('#Passw').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Passw').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var selected = []
    var checkboxes = document.querySelectorAll('input[name=inList]:checked');

    for (var i = 0; i < checkboxes.length; i++) {
        selected.push(checkboxes[i].value);
    }
    //--------------------------------------------------------------------------------
      
    var data = {

        'ID': $('#ID').val(),
        'Logi': $('#Logi').val(),
        'Passw': $('#Passw').val(),
        'idFIO': $('#idFIO').val(),
        'UserLog': $('#UserLog').val(),
        'DateLog': $('#DateLog').val(),
        'ddd': selected

    };

    $.ajax({
        url: "/Home/LoginEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}