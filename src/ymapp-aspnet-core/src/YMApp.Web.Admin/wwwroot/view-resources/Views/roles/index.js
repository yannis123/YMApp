layui.use(['laydate', 'table', 'form'], function () {
    var laydate = layui.laydate;
    var form = layui.form;
    var table = layui.table;
    var _roleService = abp.services.app.role;


    var _table = table.render({
        elem: '#list'
        , url: '/api/services/app/role/GetAll' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , { field: 'name', title: '角色名称' }
            , { field: 'description', title: '描述' }
            , { fixed: 'right', width: 165, align: 'center', toolbar: '#barDemo' }
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

    //监听行工具事件
    table.on('tool(test)', function (obj) { //注：tool 是工具条事件名，test 是 table 原始容器的属性 lay-filter="对应的值"
        var data = obj.data //获得当前行数据
            , layEvent = obj.event; //获得 lay-event 对应的值
        if (layEvent === 'edit') {
            xadmin.open('编辑', '/roles/edit?id=' + data.id);
        } else if (layEvent === 'del') {
            layer.confirm('真的删除行么', function (index) {
                _roleService.delete({ id: data.id }).done(function () {
                    obj.del(); //删除对应行（tr）的DOM结构
                    layer.close(index);
                    layer.msg('删除成功!', { icon: 1, time: 1000 });
                }).always(function () {
                    //abp.ui.clearBusy(_$modal);
                });

            });
        }
    });

});
