layui.use(['form', 'jquery', 'layer', 'upload', 'treeSelect', 'laydate'], function () {
    var laydate = layui.laydate;
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload
        , treeSelect = layui.treeSelect;

    var _userService = abp.services.app.user;

    //自定义验证规则
    form.verify({
        confirmPassword: function (value) {
            if (value != $("input[name='password']").val()) {
                return '密码输入不一致';
            }
        }
    });

    //监听提交
    form.on('submit(save)', function (data) {
        var roles = new Array();

        var cks = $("input[name='role']:checked");
        $.each(cks, function (index, item) {
            roles.push($(item).val());
        });
        data.field.roleNames = roles;
        data.field.isActive = data.field.isActive ? true : false;

        if (data.field.id > 0) {
            _userService.update(data.field).done(function () {
                window.parent.location.reload();
                // 获得frame索引
                var index = parent.layer.getFrameIndex(window.name);
                //关闭当前frame
                parent.layer.close(index);
            });
        } else {
            _userService.create(data.field).done(function () {
                window.parent.location.reload();
                // 获得frame索引
                var index = parent.layer.getFrameIndex(window.name);
                //关闭当前frame
                parent.layer.close(index);
            });
        }
        return false;
    });

});