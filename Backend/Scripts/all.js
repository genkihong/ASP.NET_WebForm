$(document).ready(function () {
    //console.log('目前的url', window.location.href);

    //後台左側選單
    $('.has-treeview a').each(function () {
        $(this).click(function () {
            $(this).addClass('active');
            $(this).parent().siblings().find('a').removeClass('active');
        });
    });

    //後台左側選單子選項
    $('.nav-treeview a').each(function () {
        //console.log('this', this);
        //console.log('a連結url(this.href)', this.href);
        //console.log('$(this)', $(this));
        //console.log('a連結url$(this)', $(this)[0].href);
        if (this.href.trim() === window.location.href) {
            $(this).addClass('active');
        }
    });

    //會員權限
    function handleCheckBox() {
        let arr = [];
        $('.uniChecked').each(function () {
            if ($(this).prop('checked')) {
                arr.push($(this).val());
            }
        });
        return arr.toString();
    }

    //單選
    $('.uniChecked').each(function () {
        $(this).change(function () {
            $('#AllCheckBox').prop('checked', false);
            $('.permission').val(handleCheckBox());
        });
    });

    //全選
    $('#AllCheckBox').click(function () {
        if ($(this).prop('checked')) {
            $('.uniChecked').each(function () {
                $(this).prop('checked', true);
            });
        } else {
            $('.uniChecked').each(function () {
                $(this).prop('checked', false);
            });
        }
        $('.permission').val(handleCheckBox());
    });

    //檢查帳號是否重覆
    $('#checkAccountBtn').click(function () {
        const name = $('#name').val();
        if (name === '') return;
        $.get('CheckAccount.ashx', { name })
            .done(function (data) {
                if (data === '1') {
                    $('#accountMessage').text('帳號已經存在!');
                } else {
                    $('#accountMessage').text('帳號可以使用');
                }
            });
    });

    //國家 id
    const id = $('#countrySelect').val();

    //將國家 id 寫入隱藏欄位
    //$('#countryValue').val(id);

    getRegion(id);

    //預設取得國家 id=1 的地區資料
    function getRegion(id = 1) {
        $.get('GetRegion.ashx', { id })
            .done(function (data) {
                regionList(data);
                modifyRegionList(data);
            }).fail(function (data) {
                alert(data.message);
            });
    }

    //經銷商地區搜尋下拉式選單
    function regionList(data) {
        const region = $('#regionSelect');//地區下拉選單
        let value = $('#regionValue').val();//地區隱藏欄位
        //let value = $('#regionValue1').val();

        region.html('');
        region.append('<option value= "0" selected="">請選擇</option>');
        $.each(data, function (index, item) {
            let option = `<option value=${item.region_id}>${item.region}</option>`;
            if (item.region_id == value) {//換頁時，如果隱藏欄位的有值，就加上selected
                option = `<option value=${item.region_id} selected="">${item.region}</option>`;
            }
            region.append(option);
        });
        //將地區 id 寫入隱藏欄位
        $('#regionValue').val(region.val());
        //console.log(region.val());
        //console.log(region.text());
    }

    //新增 / 修改經銷商地區下拉式選單
    function modifyRegionList(data) {
        const region = $('#modifyRegionSelect');
        region.html('');
        $.each(data, function (index, item) {
            let option = `<option value=${item.region_id}>${item.region}</option>`;
            region.append(option);
        });
        //html() 寫法
        //let str = '';
        //$.each(data, function (index, item) {
        //    str += `<option value=${item.region_id}>${item.region}</option>`;
        //});
        //region.html(str);
    }

    //經銷商國家搜尋
    $('#countrySelect').change(function () {
        const countryId = $(this).val();
        //$('#countryValue').val(countryId);//將國家 id 寫入隱藏欄位
        getRegion(countryId);//取得選取國家的地區資料
    });

    //經銷商地區搜尋
    $('#regionSelect').change(function () {
        const regionId = $(this).val();
        $('#regionValue').val(regionId);//將地區 id 寫入隱藏欄位
    });


    //圖片預覽
    function readURL(input, type) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                type.attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]); // convert to base64 string
        }
    }

    $("#user_img").change(function () {
        const user = $('.user_img');
        readURL(this, user);
    });

    $("#yacht_img").change(function () {
        const user = $('.yacht_img');
        readURL(this, user);
    });

    $("#news_img").change(function () {
        const user = $('.news_img');
        readURL(this, user);
    });

    $("#dealers_img").change(function () {
        const dealer = $('.dealers_img');
        readURL(this, dealer);
    });

    //light box
    $(document).on('click', '[data-toggle="lightbox"]', function (event) {
        event.preventDefault();
        $(this).ekkoLightbox({
            alwaysShowClose: true
        });
    });
});