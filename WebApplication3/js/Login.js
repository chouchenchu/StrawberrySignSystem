$(document).ready(function () {
    if (localStorage.getItem('StoreCode') != null) {
        document.getElementById('StoreCode').value = localStorage.getItem('StoreCode');
        document.getElementById('AuthorityID').value = localStorage.getItem('AuthorityID');
        //document.getElementById('AuthorityPassword').value = localStorage.getItem('AuthorityPassword');
        $('#pwRemember').prop('checked', true);
    }
    $(document).on("click", "#loginForm", function () {


        var postData = {
            StoreCode: $.trim($("#StoreCode").val()),
            AuthorityID: $.trim($("#AuthorityID").val()),
            AuthorityPassword: $.trim($("#AuthorityPassword").val()),
            //captchaCode: $.trim($("#captchaCode").val()),
        };
        $.ajax({
            url: '/LoginView/Login',
            type: "post",
            data: postData,
            success: function (obj) {
                if (obj.Successed) {
                    if ($('#pwRemember').prop('checked')) {
                        localStorage.setItem('StoreCode', postData.StoreCode);
                        localStorage.setItem('AuthorityID', postData.AuthorityID);
                        //localStorage.setItem('AuthorityPassword', postData.AuthorityPassword);
                        redirectToIndex(obj);
                    } else {
                        localStorage.removeItem('StoreCode');
                        localStorage.removeItem('AuthorityID');
                        //localStorage.removeItem('AuthorityPassword');
                        redirectToIndex(obj);
                    }


                }
                else {
                    $('#modal-placeholder').html(obj).find('.modal').modal('show');
                }
            }
        });
    });
}