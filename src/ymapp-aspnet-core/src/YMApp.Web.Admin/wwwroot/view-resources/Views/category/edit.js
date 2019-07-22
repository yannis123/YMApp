layui.use(['form', 'jquery', 'layer', 'upload', 'treeSelect', 'laydate'], function () {
    var laydate = layui.laydate;
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload
        , treeSelect = layui.treeSelect;

    var _categoryService = abp.services.app.category;

    treeSelect.render({
        // 选择器
        elem: '#ParentId',
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
            //console.log(d);
        },
        // 加载完成后的回调函数
        success: function (d) {
            // console.log(d);
            //                选中节点，根据id筛选
            //                treeSelect.checkNode('tree', 3);
            var id = $("#parentCategoryId").val();
            treeSelect.checkNode('ParentId', id);
            //                获取zTree对象，可以调用zTree方法
            //                var treeObj = treeSelect.zTree('tree');
            //                console.log(treeObj);

            //                刷新树结构
            //                treeSelect.refresh();
        }
    });
    
    //监听提交
    form.on('submit(save)', function (data) {
        _categoryService.createOrUpdate({ category: data.field }).done(function () {
            window.parent.location.reload();
            //parent.layui.table.reload("list");
            // 获得frame索引
            var index = parent.layer.getFrameIndex(window.name);
            //关闭当前frame
            parent.layer.close(index);
        });
        return false;
    });


});