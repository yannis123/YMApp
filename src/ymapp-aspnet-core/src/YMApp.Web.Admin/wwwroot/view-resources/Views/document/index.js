layui.use(['laydate', 'table', 'form'], function () {
    var laydate = layui.laydate;
    var form = layui.form;
    var table = layui.table;
    var _documentService = abp.services.app.document;

    //执行一个laydate实例
    laydate.render({
        elem: '#start' //指定元素
    });

    //执行一个laydate实例
    laydate.render({
        elem: '#end' //指定元素
    });
    var _table = table.render({
        elem: '#list'
        , url: '/api/services/app/document/GetPaged' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , {
                field: 'categoryId', title: '分类', templet: function (d) {
                    return d.category.name;
                }
            }
            , { field: 'name', title: '文件名称' }
            , { field: 'name', title: '文件大小' }
            , { field: 'describe', title: '文件描述' }
            , { field: 'creationTime', title: '上传时间' }
            //, { field: 'creatorUserId', title: '上传人' }
            , { field: 'state', title: '审核状态', templet: '#stateTpl' }
            , {
                field: '', title: '', templet: function (d) {
                    return "<a  href='/files/download?id=" + d.id + "'><i class='icon iconfont'></i>下载<a>";
                }
            }
            , { fixed: 'right', width: 165, align: 'center', toolbar: '#barDemo', title: '操作' }
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
    //监听状态操作
    form.on('switch(state)', function (obj) {
        _documentService.changeAuditState({ id: this.value, state: obj.elem.checked ? 1 : 0 }).done(function () {
            layer.msg('修改成功!', { icon: 1, time: 1000 });
        });
        return false;
    });

    //监听行工具事件
    table.on('tool(test)', function (obj) { //注：tool 是工具条事件名，test 是 table 原始容器的属性 lay-filter="对应的值"
        var data = obj.data //获得当前行数据
            , layEvent = obj.event; //获得 lay-event 对应的值
        if (layEvent === 'edit') {
            xadmin.open('编辑', '/document/edit?id=' + data.id, 800, 600);
        } else if (layEvent === 'del') {
            layer.confirm('真的删除行么', function (index) {
                _documentService.delete({ id: data.id }).done(function () {
                    obj.del(); //删除对应行（tr）的DOM结构
                    layer.close(index);
                    layer.msg('删除成功!', { icon: 1, time: 1000 });
                }).always(function () {
                    //abp.ui.clearBusy(_$modal);
                });

            });
        }
    });

    form.on('submit(search)', function (data) {
        _table.reload({
            where: data.field
            , page: {
                curr: 1 //重新从第 1 页开始
            }
        });
        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    });

});
