layui.use(['laydate', 'form', 'table'],
    function () {
        var laydate = layui.laydate;
        var table = layui.table;
        var form = layui.form;
        var _articleService = abp.services.app.article;
        //执行一个laydate实例
        laydate.render({
            elem: '#Start' //指定元素
        });

        //执行一个laydate实例
        laydate.render({
            elem: '#End' //指定元素
        });

        var _table = table.render({
            elem: '#list'
            , height: 312
            , url: '/api/services/app/article/GetPaged' //数据接口
            , parseData: function (res) { //res 即为原始返回的数据
                return {
                    "code": 0, //解析接口状态
                    "msg": res.error, //解析提示文本
                    "count": res.result.totalCount, //解析数据长度
                    "data": res.result.items //解析数据列表
                };
            }
            , request: {
                pageName: 'pageIndex' //页码的参数名称，默认：page
                , limitName: 'pageSize' //每页数据量的参数名，默认：limit
            }
            , page: true //开启分页
            , cols: [[ //表头
                { field: 'id', title: 'ID', width: 80, sort: true, fixed: 'left' }
                , { field: 'title', title: '标题' }
                , {
                    field: 'categoryId', title: '分类', sort: true, templet: function (d) {
                        return d.category.name;
                    }
                }
                , { field: 'author', title: '作者' }
                , { field: 'source', title: '来源'}
                , { field: 'creationTime', title: '创建时间' }
                , { field: 'state', title: '状态', templet: '#stateTpl' }
                , { fixed: 'right', width: 165, align: 'center', toolbar: '#barDemo' }
            ]]
        });
        //监听状态操作
        form.on('switch(state)', function (obj) {
            _articleService.changeAuditState({ id: this.value, state: obj.elem.checked ? 1 : 0 }).done(function () {
               // layer.tips("修改成功", obj.othis);
                layer.msg('修改成功!', { icon: 1, time: 1000 });
            });
            return false;
        });

        //监听行工具事件
        table.on('tool(test)', function (obj) { //注：tool 是工具条事件名，test 是 table 原始容器的属性 lay-filter="对应的值"
            var data = obj.data //获得当前行数据
                , layEvent = obj.event; //获得 lay-event 对应的值
            if (layEvent === 'detail') {
                xadmin.open('编辑', '/product/edit?id=' + data.id);
            } else if (layEvent === 'del') {
                layer.confirm('真的删除行么', function (index) {
                    _articleService.delete({ id: data.id }).done(function () {
                        obj.del(); //删除对应行（tr）的DOM结构
                        layer.close(index);
                        layer.msg('删除成功!', { icon: 1, time: 1000 });
                    }).always(function () {
                        //abp.ui.clearBusy(_$modal);
                    });

                });
            } else if (layEvent === 'edit') {
                xadmin.open('编辑', '/article/edit?id=' + data.id, '', '', true);
            }
        });

        form.on('submit(search)', function (data) {
            console.log(data.field);//当前容器的全部表单字段，名值对形式：{name: value}
            _table.reload({
                where: data.field
                , page: {
                    curr: 1 //重新从第 1 页开始
                }
            });
            return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
        });
    });