$(document).ready(function () {

	if (localStorage.getItem('StoreCode') != null) {
		document.getElementById('StoreCode').value = localStorage.getItem('StoreCode');
		document.getElementById('Account').value = localStorage.getItem('Account');
		//document.getElementById('Password').value = localStorage.getItem('Password');
		$('#pwRemember').prop('checked', true);
	}


	$(document).on("click", "#LoginClick", function () {

		var postData = {
			StoreCode: $.trim($("#StoreCode").val()),
			Account: $.trim($("#Account").val()),
			Password: $.trim($("#Password").val()),
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
						localStorage.setItem('Account', postData.Account);
						localStorage.setItem('Password', postData.Password);
						redirectToIndex(obj);
					} else {
						localStorage.removeItem('StoreCode');
						localStorage.removeItem('Account');
						//localStorage.removeItem('Password');
						redirectToIndex(obj);
					}


				}
				else {
					//return View("View/Login.cshtml");	
					$('#modal-placeholder').html(obj).find('.modal').modal('show');
				}
			}
		});
	});
})