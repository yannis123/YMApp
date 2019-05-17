layui.use(['form', 'jquery', 'layer', 'upload', 'treeSelect', 'laydate'], function () {
    var laydate = layui.laydate;
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload
        , treeSelect = layui.treeSelect;

    var _tripService = abp.services.app.trip;

    //自定义验证规则
    form.verify({
        Describe: function (value) {
            if (value.length > 200) {
                return '线路简介不能大于200';
            }
        }
    });

    //监听提交
    form.on('submit(add)', function (data) {
        _tripService.createOrUpdate(data.field).done(function () {
            window.parent.location.reload();
            // 获得frame索引
            var index = parent.layer.getFrameIndex(window.name);
            //关闭当前frame
            parent.layer.close(index);
        });
        return false;
    });

    var ue = UE.getEditor('TripDesc', {
        initialFrameHeight: 320
    });

});