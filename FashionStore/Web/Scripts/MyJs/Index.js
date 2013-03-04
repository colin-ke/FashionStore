$(function () {
    //搜索框
    var $hdText = $('#hd2-sr .hd-text');
    $hdText.val('女装T恤');
    $hdText.focus(function () {
        $(this).select();
        $(this).removeClass('lower');
        if ($(this).val() == this.defaultValue) {
            $(this).val('');
        }
    }).blur(function () {
        if ($(this).val() == '') {
            $(this).addClass('lower').val(this.defaultValue);
        }
    });
    $('#hd2-sr form:first').submit(function () {
        if ($hdText.val() == $hdText[0].defaultValue || $hdText.val() == '') {
            return false;
        }
    });
    //新COMM
    if ($.browser.msie && $.browser.version == 6) {
        $('#hd2_nav > li').hover(function () {
            var $slideDiv = $(this).find('div.navp');
            if ($slideDiv.length === 0) {
                return;
            }
            $(this).children("a").addClass("hover");
            $slideDiv.show();
            $(this).append('<iframe id="selectMask" style="position:absolute;left:0;z-index:-1;" frameborder="0"></iframe>');
            $('#selectMask').height($slideDiv.height() + 3).width($slideDiv.width() + 6);
        },
	function () {
	    var $that = $(this);
	    var $slideDiv = $(this).find('div.navp');
	    if ($slideDiv.length === 0) {
	        return;
	    }
	    $slideDiv.hide(0);
	    $(this).find('iframe').remove().children("a").removeClass('hover');
	});
        //修复IE6不缓存背景图
        try { document.execCommand('BackgroundImageCache', false, true); } catch (e) { }
    }
    //下拉导航
    $("#showFdivmc > li").hover(function () {
        var $slideDiv = $(this).find('div.navp');
        if ($slideDiv.length === 0) {
            return;
        }
        $(this).children("a").addClass("hover");
        $slideDiv.show();
    }, function () {
        var $that = $(this);
        var $slideDiv = $(this).find('div.navp');
        if ($slideDiv.length === 0) {
            return;
        }
        $slideDiv.hide();
        $(this).children("a").removeClass('hover');
    });
    //我的麦网下拉
    $("#hd2 li.myPage").hover(function () {
        $(this).children("ul").show();
        $(this).addClass("hover");
        $(this).css({ paddingLeft: "10px", paddingRight: "11px", marginTop: "-1px" });
    }, function () {
        $(this).children("ul").hide();
        $(this).removeClass("hover");
        $(this).css({ paddingLeft: "11px", paddingRight: "11px", marginTop: "0px" });
    });
    //购物车效果
    $("#hd2-cart").hover(function () {
        $(this).addClass("hover");
    }, function () {
        $(this).removeClass("hover")
    });
    //新导航结束

    //页脚hover效果
    $("#help2").find("dl").hover(function () {
        $(this).addClass("cur");
    },
	function () {
	    $(this).removeClass("cur");
	});
    //DOMreader结束
});