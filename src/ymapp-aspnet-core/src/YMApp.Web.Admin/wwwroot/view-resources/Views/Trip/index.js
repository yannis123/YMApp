layui.use(['laydate', 'table', 'treeSelect'], function () {
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var _tripService = abp.services.app.trip;
    var projectTab = table.render({
        elem: '#tripList'
        , url: '/api/services/app/Trip/GetPaged' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , { field: 'tripName', title: '行程名称' }
            , { field: 'tripPrice', title: '行程价格' }
           // , { field: 'status', title: '状态', templet: '#statusTpl' }
            , { field: 'createTime', title: '创建日期' }
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


    //监听推荐操作
    form.on('checkbox(stataus)', function (obj) {
        _tripService.chnageTripState({ id: this.value, state: obj.elem.checked ? 1 : 0 }).done(function () {
            layer.tips("修改成功", obj.othis);
        });
        return false;
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

/*用户-删除*/
function member_del(obj, id) {
    layer.confirm('确认要删除吗？', function (index) {
        //发异步删除数据
        $(obj).parents("tr").remove();
        layer.msg('已删除!', { icon: 1, time: 1000 });
    });
}

function delAll(argument) {

    var data = tableCheck.getData();

    layer.confirm('确认要删除吗？' + data, function (index) {
        //捉到所有被选中的，发异步进行删除
        layer.msg('删除成功', { icon: 1 });
        $(".layui-form-checked").not('.header').parents('tr').remove();
    });
}