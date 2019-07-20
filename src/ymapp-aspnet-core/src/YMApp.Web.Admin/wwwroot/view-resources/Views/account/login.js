$(function () {
    layui.use('form', function () {
        var form = layui.form;
        // layer.msg('玩命卖萌中', function(){
        //   //关闭后的操作
        //   });
        //监听提交
        form.on('submit(login)', function (data) {
            abp.ajax({
                contentType: 'application/x-www-form-urlencoded',
                url: "/account/login",
                data: data.field
            });
            //$.post("/account/login", data.field, function (resp) {
            //    if (resp.success) {
            //        location.href = resp.targetUrl;
            //    } else {
            //        layui.msg(resp.error);
            //    }
            //});
            return false;
        });
    });
})