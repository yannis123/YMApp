layui.use(['form', 'layer'], function () {
    $ = layui.jquery;
    var form = layui.form
        , layer = layui.layer;

    var _roleService = abp.services.app.role;

    //自定义验证规则
    form.verify({
        nikename: function (value) {
            if (value.length < 5) {
                return '昵称至少得5个字符啊';
            }
        }
        , pass: [/(.+){6,12}$/, '密码必须6到12位']
        , repass: function (value) {
            if ($('#L_pass').val() != $('#L_repass').val()) {
                return '两次密码不一致';
            }
        }
    });

    //监听提交
    form.on('submit(save)', function (data) {
        var permissions = new Array();

        var cks = $("input[name='permission']:checked");
        $.each(cks, function (index, item) {
            permissions.push($(item).val());
        });

        var role = {
            id: data.field.id,
            name: data.field.name,
            displayName: data.field.displayName,
            description: data.field.description,
            isDefault: data.field.isDefault ? true : false,
            permissions: permissions
        };
        if (data.field.id > 0) {
            _roleService.update(role).done(function () {
               // window.parent.location.reload();
                parent.layui.table.reload("list");
                // 获得frame索引
                var index = parent.layer.getFrameIndex(window.name);
                //关闭当前frame
                parent.layer.close(index);
                parent.layui.table.reload('table');
            });
        } else {
            _roleService.create(role).done(function () {
                //window.parent.location.reload();
                parent.layui.table.reload("list");
                // 获得frame索引
                var index = parent.layer.getFrameIndex(window.name);
                //关闭当前frame
                parent.layer.close(index);
            });
        }
        return false;
    });


    form.on('checkbox(father)', function (data) {

        if (data.elem.checked) {
            $(data.elem).parent().siblings('td').find('input').prop("checked", true);
            form.render();
        } else {
            $(data.elem).parent().siblings('td').find('input').prop("checked", false);
            form.render();
        }
    });


});