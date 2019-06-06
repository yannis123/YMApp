layui.use(['form', 'jquery', 'layer', 'upload', 'laydate'], function () {
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload;

    var _articleService = abp.services.app.article;


    //监听提交
    form.on('submit(demo2)', function (data) {
        _articleService.createOrUpdate({ article: data.field }).done(function () {
            window.parent.location.reload();
            //获得frame索引
            var index = parent.layer.getFrameIndex(window.name);
            //关闭当前frame
            parent.layer.close(index);
        });
        return false;
    });

    var ue = UE.getEditor('TextContent', {
        initialFrameHeight: 320
    });
});