layui.use(['form', 'jquery', 'layer', 'upload', 'laydate'], function () {
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload;

    var _tripService = abp.services.app.trip;

    var uploadInst = upload.render({
        elem: '#upload' //绑定元素
        , url: '/pictures/post' //上传接口
        , done: function (res) {
            //上传完毕回调
            var file = res.result.data[0];
            $("input[name='pictureUrl']").val(file.filePath);
            $("#pictureUrl").attr("src", file.filePath);
        }
        , error: function () {
            //请求异常回调
            layer.msg('上传失败!', { icon: 1, time: 1000 });
        }
    });

    //监听提交
    form.on('submit(save)', function (data) {
        _tripService.createOrUpdate({ trip: data.field }).done(function () {
            //window.parent.location.reload();
            parent.layui.table.reload("list");
            //获得frame索引
            var index = parent.layer.getFrameIndex(window.name);
            //关闭当前frame
            parent.layer.close(index);
        });
        return false;
    });

    var ue = UE.getEditor('Content', {
        initialFrameHeight: 320
    });
});