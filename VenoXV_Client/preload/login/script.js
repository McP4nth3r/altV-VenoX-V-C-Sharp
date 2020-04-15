//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let WindowOpen = false;
let PasswordVisible = false;


function LoadLoginWindowEvents() {
    // Login
    $("#login_button").click(function () {
        if (!WindowOpen) {
            $("#login_button").addClass('Button_Active');
            $("#window_login").removeClass('d-none');
            WindowOpen = true;
        }
    });

    $("#window_login_close").click(function () {
        $("#login_button").removeClass('Button_Active');
        $("#window_login").addClass('d-none');
        WindowOpen = false;
    });

    // Register
    $("#register_button").click(function () {
        if (!WindowOpen) {
            $("#register_button").addClass('Button_Active');
            $("#window_register").removeClass('d-none');
            WindowOpen = true;
        }
    });

    $("#window_register_close").click(function () {
        $("#register_button").removeClass('Button_Active');
        $("#window_register").addClass('d-none');
        WindowOpen = false;
    });


    $("#window_login_button").click(function () {
        let name = document.getElementById('usernamee').value;
        let password = document.getElementById('passwordd').value;
        alt.emit('request_player_login', name, password);
    });

    $("#pass_view_click_view").click(function () {
        if (!PasswordVisible) {
            document.getElementById("passwordd").attributes["type"].value = "text";
            PasswordVisible = true;
            $("#pass_view_click_view").addClass('d-none');
            $("#pass_view_click_hide").removeClass('d-none');
        }
    });

    $("#pass_view_click_hide").click(function () {
        if (PasswordVisible) {
            document.getElementById("passwordd").attributes["type"].value = "password";
            PasswordVisible = false;
            $("#pass_view_click_hide").addClass('d-none');
            $("#pass_view_click_view").removeClass('d-none');
        }
    });
}


$(document).ready(function () {
    LoadLoginWindowEvents();

    $('#task_privacypolicy_clicked').click(function () {
        if (!WindowOpen) {
            $('#privacypolicy_window').removeClass('d-none');
            WindowOpen = true;
        }
    });

    $('#window_privacypolicy_close').click(function () {
        if (WindowOpen) {
            $('#privacypolicy_window').addClass('d-none');
            WindowOpen = false;
        }
    });
});