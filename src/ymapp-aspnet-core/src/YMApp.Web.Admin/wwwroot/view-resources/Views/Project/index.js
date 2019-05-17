layui.use(['laydate', 'table', 'treeSelect'], function () {
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var treeSelect = layui.treeSelect;

    var _projectService = abp.services.app.project;

    //执行一个laydate实例
    laydate.render({
        elem: '#StartTime' //指定元素
    });

    //执行一个laydate实例
    laydate.render({
        elem: '#EndTime' //指定元素
    });

    var projectTab = table.render({
        elem: '#projectList'
        //, url: '/project/ProjectList' //数据接口 
        , url: '/api/services/app/Project/GetProjectList' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , { field: 'name', title: '名称' }
            , { field: 'categoryName', title: '所属分类' }
            , { field: 'price', title: '价格' }
            , { field: 'startDate', title: '发团日期' }
            , { field: 'isRecommend', title: '是否推荐', templet: '#isRecommendTpl' }
            , { field: 'state', title: '状态', templet: '#stateTpl' }
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
    //监听状态操作
    form.on('switch(state)', function (obj) {
        _projectService.changeProjectAuditState({ id: this.value, state: obj.elem.checked ? 1 : 0 }).done(function () {
            layer.tips("修改成功",obj.othis);
        });
        return false;
    });

    //监听推荐操作
    form.on('checkbox(isRecommend)', function (obj) {
        _projectService.changeProjectRecommendState({ id: this.value, state: obj.elem.checked ? 1 : 0 }).done(function () {
            layer.tips("修改成功",obj.othis);
        });
        return false;
    });
    //监听工具条
    table.on('tool(projectList)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                _projectService.delete({ id: data.id }).done(function () {
                    obj.del();
                    layer.close(index);
                }).always(function () {

                });
            });
        } else if (obj.event === 'edit') {
            //layer.alert('编辑行：<br>' + JSON.stringify(data))
            x_admin_show("编辑线路", "/project/editproject?projectId=" + data.id);
        }
    });

    form.on('submit(searchProject)', function (data) {
        console.log(data.field) //当前容器的全部表单字段，名值对形式：{name: value}
        projectTab.reload({
            where: data.field
            , page: {
                curr: 1 //重新从第 1 页开始
            }
        });
        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    })

    treeSelect.render({
        // 选择器
        elem: '#CategoryId',
        // 数据
        data: '/category/GetCategoryTree',
        // 异步加载方式：get/post，默认get
        type: 'get',
        // 占位符
        placeholder: '请选择分类',
        // 是否开启搜索功能：true/false，默认false
        search: true,
        // 点击回调
        click: function (d) {
            console.log(d);
        },
        // 加载完成后的回调函数
        success: function (d) {

        }
    });

    $("#addproject").click(function () {
        x_admin_show("编辑线路", "/project/editproject");
    });
});

/*用户-停用*/
function member_stop(obj, id) {
    layer.confirm('确认要停用吗？', function (index) {

        if ($(obj).attr('title') == '启用') {

            //发异步把用户状态进行更改
            $(obj).attr('title', '停用')
            $(obj).find('i').html('&#xe62f;');

            $(obj).parents("tr").find(".td-status").find('span').addClass('layui-btn-disabled').html('已停用');
            layer.msg('已停用!', { icon: 5, time: 1000 });

        } else {
            $(obj).attr('title', '启用')
            $(obj).find('i').html('&#xe601;');

            $(obj).parents("tr").find(".td-status").find('span').removeClass('layui-btn-disabled').html('已启用');
            layer.msg('已启用!', { icon: 5, time: 1000 });
        }

    });
}
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