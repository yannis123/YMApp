layui.use(['form', 'jquery', 'layer', 'upload', 'treeSelect', 'laydate'], function () {
    var laydate = layui.laydate;
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload;

    var _documentService = abp.services.app.document;

    //自定义验证规则
    form.verify({
        confirmPassword: function (value) {
            if (value != $("input[name='password']").val()) {
                return '密码输入不一致';
            }
        }
    });

    var uploadInst = upload.render({
        elem: '#upload' //绑定元素
        , url: '/files/upload' //上传接口
        , done: function (res) {
            //上传完毕回调
            var file = res.result.data[0];
            $("input[name='filePath']").val(file.filePath);
            $("input[name='oriName']").val(file.fileName);
            $("input[name='fileSize']").val(file.fileSize);
            $("#fileName").html(file.fileName);
        }
        , error: function () {
            //请求异常回调
            layer.msg('上传失败!', { icon: 1, time: 1000 });
        }
    });

    //监听提交
    form.on('submit(save)', function (data) {
        _documentService.createOrUpdate({ "document": data.field }).done(function () {
            window.parent.location.reload();
            // 获得frame索引
            var index = parent.layer.getFrameIndex(window.name);
            //关闭当前frame
            parent.layer.close(index);
        });
        return false;
    });

});