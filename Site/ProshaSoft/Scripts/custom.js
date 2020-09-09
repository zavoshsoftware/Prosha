function SubmitComment() {
     var url = window.location.pathname;
     var id = url.substring(url.lastIndexOf('/') + 1);

     var nameVal = $("#commentName").val();
    var emailVal = $("#commentEmail").val();
    var bodyVal = $("#commentBody").val();

    if (nameVal !== "" && emailVal !== "" && bodyVal !== "") {
        $.ajax(
            {
                url: "/ProductComments/PostSubmitComment",
                data: { name: nameVal, email: emailVal, body: bodyVal, id: id },
                type: "POST"

            }).done(function (result) {
            if (result === "true") {
                $("#comment-reject").css('display', 'none');
                $("#comment-succes").css('display', 'block');
                localStorage.setItem("id", "");
            }
            else if (result === "InvalidEmail") {
                $("#comment-reject").html('ایمیل وارد شده صحیح نمی باشد.');
                $("#comment-reject").css('display', 'block');
                $("#comment-succes").css('display', 'none');
            }
            else if (result === "false") {
                $("#comment-reject").html('خطایی رخ داده است. لطفا مجددا وارد صفحه شوید و تلاش کنید.');
                $("#comment-reject").css('display', 'block');
                $("#comment-succes").css('display', 'none');
            }
        });
    }
    else {
        $("#comment-reject").html('تمامی فیلد های زیر را تکمیل نمایید.');
        $("#comment-reject").css('display', 'block');
        $("#comment-succes").css('display', 'none');

    }
}


function SubmitCommentForBlog() {
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);

    var nameVal = $("#commentName").val();
    var emailVal = $("#commentEmail").val();
    var bodyVal = $("#commentBody").val();

    if (nameVal !== "" && emailVal !== "" && bodyVal !== "") {
        $.ajax(
            {
                url: "/BlogComments/PostSubmitComment",
                data: { name: nameVal, email: emailVal, body: bodyVal, urlParam: decodeURIComponent(id) },
                type: "POST"

            }).done(function (result) {
            if (result === "true") {
                $("#comment-reject").css('display', 'none');
                $("#comment-succes").css('display', 'block');
                localStorage.setItem("id", "");
            }
            else if (result === "InvalidEmail") {
                $("#comment-reject").html('ایمیل وارد شده صحیح نمی باشد.');
                $("#comment-reject").css('display', 'block');
                $("#comment-succes").css('display', 'none');
            }
            else if (result === "false") {
                $("#comment-reject").html('خطایی رخ داده است. لطفا مجددا وارد صفحه شوید و تلاش کنید.');
                $("#comment-reject").css('display', 'block');
                $("#comment-succes").css('display', 'none');
            }
        });
    }
    else {
        $("#comment-reject").html('تمامی فیلد های زیر را تکمیل نمایید.');
        $("#comment-reject").css('display', 'block');
        $("#comment-succes").css('display', 'none');

    }
}



function SubmitContactUs() {
 

    var nameVal = $("#contact-name").val();
    var emailVal = $("#contact-email").val();
    var bodyVal = $("#contact-message").val();

    if (nameVal !== "" && emailVal !== "" && bodyVal !== "") {
        $.ajax(
            {
                url: "/ContactUsForms/PostSubmitContactForm",
                data: { name: nameVal, email: emailVal, body: bodyVal },
                type: "POST"

            }).done(function (result) {
            if (result === "true") {
                $("#comment-reject").css('display', 'none');
                $("#comment-succes").css('display', 'block');
                localStorage.setItem("id", "");
            }
            else if (result === "InvalidEmail") {
                $("#comment-reject").html('ایمیل وارد شده صحیح نمی باشد.');
                $("#comment-reject").css('display', 'block');
                $("#comment-succes").css('display', 'none');
            }
            else if (result === "false") {
                $("#comment-reject").html('خطایی رخ داده است. لطفا مجددا وارد صفحه شوید و تلاش کنید.');
                $("#comment-reject").css('display', 'block');
                $("#comment-succes").css('display', 'none');
            }
        });
    }
    else {
        $("#comment-reject").html('تمامی فیلد های زیر را تکمیل نمایید.');
        $("#comment-reject").css('display', 'block');
        $("#comment-succes").css('display', 'none');

    }
}
