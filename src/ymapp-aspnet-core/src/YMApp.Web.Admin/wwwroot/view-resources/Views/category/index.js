layui.use(['jquery', 'treetable'], function () {
    var $ = layui.jquery;
    var treetable = layui.treetable;
    var table = layui.table;
    var _categoryService = abp.services.app.category;

    // 渲染表格
    treetable.render({
        treeColIndex: 1,          // treetable新增参数
        treeSpid: 0,
        height: 600,// treetable新增参数
        treeIdName: 'id',       // treetable新增参数
        treePidName: 'parentId',     // treetable新增参数
        treeDefaultClose: true,   // treetable新增参数
        treeLinkage: true,        // treetable新增参数
        elem: '#table',
        url: '/api/services/app/category/GetTreeTableByType',
        cols: [[
            { type: 'numbers', width: 80 },
            { field: 'name', title: '名称' },
            {
                field: 'type', width: 120, align: 'center', templet: function (d) {
                    if (d.type === 1) {
                        return '<span class="layui-badge layui-bg-green">商品</span>';
                    }
                    if (d.type === 2) {
                        return '<span class="layui-badge layui-bg-blue">文章</span>';
                    } else if (d.type === 3) {
                        return '<span class="layui-badge layui-bg-yellow">文件</span>';
                    } else {
                        return '<span class="layui-badge-rim">其他</span>';
                    }
                }, title: '类型'
            },
            { templet: '#oper-col', width: 200, title: '操作' }
        ]]
    });

    //监听工具条
    table.on('tool(table)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;

        if (layEvent === 'del') {
            _categoryService.delete({ id: data.id }).done(function () {
                obj.del(); //删除对应行（tr）的DOM结构
                layer.close(index);
            }).always(function () {
                //abp.ui.clearBusy(_$modal);
            });

        } else if (layEvent === 'edit') {
            xadmin.open('编辑', '/category/edit?id=' + data.id, "600", "400");
        }
    });

    $('#btn-expand').click(function () {
        treetable.expandAll('#table');
    });

    $('#btn-fold').click(function () {
        treetable.foldAll('#table');
    });

    $('#btn-search').click(function () {
        var keyword = $('#name').val();
        var searchCount = 0;
        $('#table').next('.treeTable').find('.layui-table-body tbody tr td').each(function () {
            $(this).css('background-color', 'transparent');
            var text = $(this).text();
            if (keyword != '' && text.indexOf(keyword) >= 0) {
                $(this).css('background-color', 'rgba(250,230,160,0.5)');
                if (searchCount == 0) {
                    treetable.expandAll('#table');
                    $('html,body').stop(true);
                    $('html,body').animate({ scrollTop: $(this).offset().top - 150 }, 500);
                }
                searchCount++;
            }
        });
        if (keyword === '') {
            layer.msg("请输入搜索内容", { icon: 5 });
        } else if (searchCount == 0) {
            layer.msg("没有匹配结果", { icon: 5 });
        }
    });

});