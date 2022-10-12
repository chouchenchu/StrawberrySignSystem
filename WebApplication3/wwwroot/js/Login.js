$(document).ready(function () {

    if (localStorage.getItem('StoreCode') != null) {
        document.getElementById('StoreCode').value = localStorage.getItem('StoreCode');
        document.getElementById('Account').value = localStorage.getItem('Account');
        //document.getElementById('AuthorityPassword').value = localStorage.getItem('AuthorityPassword');
        $('#pwRemember').prop('checked', true);
    }


    $(document).on("click", "#LoginClick", function () {

        var postData = {
            StoreCode: $.trim($("#StoreCode").val()),
            AuthorityID: $.trim($("#Account").val()),
            AuthorityPassword: $.trim($("#AuthorityPassword").val()),
            //captchaCode: $.trim($("#captchaCode").val()),
        };
        $.ajax({
            url: '/Login/Login',
            type: "post",
            data: postData,
            success: function (obj) {
                if (obj.Successed) {
                    if ($('#pwRemember').prop('checked')) {
                        localStorage.setItem('StoreCode', postData.StoreCode);
                        localStorage.setItem('Account', postData.AuthorityID);
                        //localStorage.setItem('AuthorityPassword', postData.AuthorityPassword);
                        redirectToIndex(obj);
                    } else {
                        localStorage.removeItem('StoreCode');
                        localStorage.removeItem('Account');
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
})