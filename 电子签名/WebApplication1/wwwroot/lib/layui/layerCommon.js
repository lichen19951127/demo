var layerCommon = {};

layerCommon.open = function (title, width, height,url) {
    ; !function () {


        //页面一打开就执行，放入ready是为了layer所需配件（css、扩展模块）加载完毕
        layer.ready(function () {
            layer.open({
                type: 2,
                title: title,
                maxmin: true,
                area: [width + 'px', height+'px'],
                content: url,
                end: function () {
                    //layer.tips('Hi', '#about', { tips: 1 })
                }
            });
        });

    }();

}

layerCommon.alert = function (title,fn) {

    ; !function () {


        //页面一打开就执行，放入ready是为了layer所需配件（css、扩展模块）加载完毕
        layer.ready(function () {
            layer.alert(title, fn); 
        });

    }();
}

layerCommon.confirm = function (msg,fn) {
    ; !function () {


        //页面一打开就执行，放入ready是为了layer所需配件（css、扩展模块）加载完毕
        layer.ready(function () {
            layer.confirm(msg, { icon: 3, title: '提示' }, function (index) {
                //do something
                fn();
                layer.close(index);
            });
        });

    }();
}

layerCommon.msg = function (title,fn) {

    ; !function () {


        //页面一打开就执行，放入ready是为了layer所需配件（css、扩展模块）加载完毕
        layer.ready(function () {
            layer.msg(title, fn);
        });

    }();
}