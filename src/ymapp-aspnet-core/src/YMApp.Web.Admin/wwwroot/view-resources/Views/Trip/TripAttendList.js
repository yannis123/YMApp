layui.use(['laydate', 'table', 'treeSelect'], function () {
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var _tripService = abp.services.app.trip;
    var projectTab = table.render({
        elem: '#tripAttendList'
        , url: '/api/services/app/TripAttend/GetPaged' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { field: 'grade', title: '班级' }
            , { field: 'name', title: '姓名' }
            , { field: 'identityNo', title: '身份证号码' }
            , { field: 'mobile', title: '家长手机' }
            , { field: 'payState', title: '支付状态' }
            , { field: 'payAmount', title: '支付金额' }
            , { fixed: 'right', title: '操作', toolbar: '#optbar', width: 200 }
        ]], response: {
            statusCode: 0 //重新规定成功的状态码为 200，table 组件默认为 0
        }
        , parseData: function (res) { //将原始数据解析成 table 组件所规定的数据
            return {
                "code": res.success ? 0 : -1, //解析接口状态
                "msg": res.error, //解析提示文本
                "count": res.result.totalCount, //解析数据长度
                "data": res.result.items //解析数据列表
            };
        }
    });

    //监听工具条
    table.on('tool(tripList)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            // layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                _tripService.delete({ id: data.id }).done(function () {
                    obj.del();
                    layer.close(index);
                }).always(function () {

                });
            });
        } else if (obj.event === 'edit') {
            x_admin_show("编辑线路", "/trip/edittrip?tripId=" + data.id);
        }
    });

    $("#addtrip").click(function () {
        x_admin_show("编辑行程", "/trip/edittrip");
    });
});
