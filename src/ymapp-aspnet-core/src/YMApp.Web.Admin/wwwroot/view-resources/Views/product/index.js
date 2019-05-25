layui.use(['laydate', 'form', 'table'],
    function () {
        var laydate = layui.laydate;
        var table = layui.table;
        var form = layui.form;
        var _productService = abp.services.app.product;
        //执行一个laydate实例
        laydate.render({
            elem: '#Start' //指定元素
        });

        //执行一个laydate实例
        laydate.render({
            elem: '#End' //指定元素
        });

        var productTabe = table.render({
            elem: '#productlist'
            , height: 312
            , url: '/api/services/app/product/GetPaged' //数据接口
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
                , { field: 'productName', title: '商品名称', width: 250 }
                , {
                    field: 'categoryId', title: '分类', width: 120, sort: true, templet: function (d) {
                        return d.category.name;
                    }
                }
                , { field: 'price', title: '价格',width: 100 }
                , { field: 'state', title: '状态', templet: '#stateTpl', width: 100 }
                , { field: 'creationTime', title: '创建时间', width: 150 }
                , { fixed: 'right', width: 165, align: 'center', toolbar: '#barDemo' }
            ]]
        });
        //监听状态操作
        form.on('switch(state)', function (obj) {
            _productService.changePrpductAuditState({ id: this.value, state: obj.elem.checked ? 1 : 0 }).done(function () {
                layer.tips("修改成功", obj.othis);
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
                    _productService.delete({ id: data.id }).done(function () {
                        obj.del(); //删除对应行（tr）的DOM结构
                        layer.close(index);
                    }).always(function () {
                        //abp.ui.clearBusy(_$modal);
                    });

                });
            } else if (layEvent === 'edit') {
                xadmin.open('编辑', '/product/edit?id=' + data.id, '', '', true);
            }
        });

        form.on('submit(searchProduct)', function (data) {
            console.log(data.field);//当前容器的全部表单字段，名值对形式：{name: value}
            productTabe.reload({
                where: data.field
                , page: {
                    curr: 1 //重新从第 1 页开始
                }
            });
            return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
        });
    });


/*用户-停用*/
function member_stop(obj, id) {
    layer.confirm('确认要停用吗？',
        function (index) {

            if ($(obj).attr('title') == '启用') {

                //发异步把用户状态进行更改
                $(obj).attr('title', '停用');
                $(obj).find('i').html('&#xe62f;');

                $(obj).parents("tr").find(".td-status").find('span').addClass('layui-btn-disabled').html('已停用');
                layer.msg('已停用!', {
                    icon: 5,
                    time: 1000
                });

            } else {
                $(obj).attr('title', '启用');
                $(obj).find('i').html('&#xe601;');

                $(obj).parents("tr").find(".td-status").find('span').removeClass('layui-btn-disabled').html('已启用');
                layer.msg('已启用!', {
                    icon: 5,
                    time: 1000
                });
            }

        });
}

/*用户-删除*/
function member_del(obj, id) {
    layer.confirm('确认要删除吗？',
        function (index) {
            //发异步删除数据
            $(obj).parents("tr").remove();
            layer.msg('已删除!', {
                icon: 1,
                time: 1000
            });
        });
}

function delAll(argument) {

    var data = tableCheck.getData();

    layer.confirm('确认要删除吗？' + data,
        function (index) {
            //捉到所有被选中的，发异步进行删除
            layer.msg('删除成功', {
                icon: 1
            });
            $(".layui-form-checked").not('.header').parents('tr').remove();
        });
}