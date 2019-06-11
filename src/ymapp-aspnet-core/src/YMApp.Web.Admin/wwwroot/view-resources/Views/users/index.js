layui.use(['laydate', 'table', 'form'], function () {
    var laydate = layui.laydate;
    var form = layui.form;
    var table = layui.table;
    var _userService = abp.services.app.user;

    //执行一个laydate实例
    laydate.render({
        elem: '#start' //指定元素
    });

    //执行一个laydate实例
    laydate.render({
        elem: '#end' //指定元素
    });
    var projectTab = table.render({
        elem: '#list'
        , url: '/api/services/app/user/GetAll' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , { field: 'userName', title: '用户名' }
            , {
                field: 'roleNames', title: '角色', templet: function (d) {
                    return d.roleNames[0];
                }
            }
            , { field: 'emailAddress', title: '邮箱地址' }
            , {
                field: 'isActive', title: '激活', templet: function (d) {
                    if (d.isActive) {
                        return '<span class="layui-btn layui-btn-normal layui-btn-mini">已启用</span>';
                    } else {
                        return '<span class="layui-btn layui-btn-gray layui-btn-mini">未启用</span>';
                    }
                }
            }
            , {
                field: 'lastLoginTime', align: "center", title: '上次登陆时间', templet: function (d) {
                    if (d.lastLoginTime === "" || d.lastLoginTime === null) return "----";
                }
            }
            , { field: 'creationTime', title: '创建时间' }
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
            xadmin.open('编辑', '/users/edit?id=' + data.id);
        } else if (layEvent === 'del') {
            layer.confirm('真的删除行么', function (index) {
                _userService.delete({ id: data.id }).done(function () {
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
