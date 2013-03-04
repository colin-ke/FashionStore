var defaultOpts = { interval: 5000, fadeInTime: 300, fadeOutTime: 200 };
//Iterate over the current set of matched elements
	var _titles = $("ul.slide-txt li");
	var _titles_bg = $("ul.op li");
	var _bodies = $("ul.slide-pic li");
	var _count = _titles.length;
	var _current = 0;
	var _intervalID = null;
	var stop = function() { window.clearInterval(_intervalID); };
	var slide = function(opts) {
		if (opts) {
			_current = opts.current || 0;
		} else {
			_current = (_current >= (_count - 1)) ? 0 : (++_current);
		};
		_bodies.filter(":visible").fadeOut(defaultOpts.fadeOutTime, function() {
			_bodies.eq(_current).fadeIn(defaultOpts.fadeInTime);
			_bodies.removeClass("cur").eq(_current).addClass("cur");
		});
		_titles.removeClass("cur").eq(_current).addClass("cur");
		_titles_bg.removeClass("cur").eq(_current).addClass("cur");
	}; //endof slide
	var go = function() {
		stop();
		_intervalID = window.setInterval(function() { slide(); }, defaultOpts.interval);
	}; //endof go
	var itemMouseOver = function(target, items) {
		stop();
		var i = $.inArray(target, items);
		slide({ current: i });
	}; //endof itemMouseOver
	_titles.hover(function() { if($(this).attr('class')!='cur'){itemMouseOver(this, _titles); }else{stop();}}, go);
	//_titles_bg.hover(function() { itemMouseOver(this, _titles_bg); }, go);
	_bodies.hover(stop, go);
	//trigger the slidebox
	go();
	
//随机展示评论
var comment={
	lower:1,
	upper:20,
	total:6,
	randomNum:function(lower, upper){
		switch (arguments.length) {
			case 1:
				return parseInt(Math.random() * lower + 1);
			case 2:
				return parseInt(Math.random() * (upper - lower + 1) + lower);
			default:
				return 0;
				}
			},
	randomNumArray:function(lower, upper, total){
		var i=0,arr=[];
		while(i<total){
			var num=comment.randomNum(lower,upper);
			if($.inArray(num,arr)===-1){
				arr.push(num);
				i++;
				}
			}
		return arr;
		},
	init:function(){
		var arr=comment.randomNumArray(comment.lower, comment.upper, comment.total);
		for (n in arr){
			var i=arr[n]-1;
			$('#commentbox dl').eq(i).removeClass('none').find('img').each(function(){
				if($(this).attr('srcLoad')){
					var imgSrcTemp=$(this).attr('srcLoad').toLowerCase();
					var index = imgSrcTemp.lastIndexOf("s");
					imgSrc = imgSrcTemp.substring(0, index) + "b" + imgSrcTemp.substring(index + 1, imgSrcTemp.length);
					$(this).attr('src',imgSrc);
					}
				});
			}
		}
	};
comment.init();

function f_RegisterEMail() {
    if (($(".email").val() == "输入您的电子邮箱地址") || ($(".email").val().length == 0)) {
        alert("EMail格式不正确");
        return;
    }

    if (!f_CheckEMail($(".email").val())) {
        window.alert("EMail格式不正确");
        $(".email").focus(function(){
			$(".email").val('')
		});
        $(".email").select();
        return;
    }
    window.open("http://www.m18.com/Contact/ContactEMailList.aspx?EMail=" + $(".email").val());
}


function f_ClearRegisterEMail() {
    if ($(".email").val() == "输入您的电子邮箱地址") {
        $(".email").val('');
    }
}

function f_CheckEMail(email) {
    if (email == null || email.length == 0)
        return true;
    if (email.indexOf(' ') >= 0)
        return false;
    var reg = /([-])?\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/i;
    var result = email.match(reg);
    if (result == null)
        return false;
    if (result[0] != email)
        return false;
    return true;
}

$(document).ready(function() {
	$(".email").focus(function(){
			$(".email").val('')
			.css("color","#333");
		})
		.blur(function(){
					   $(".email").css("color","#CCC");
					   })
		.css("color","#CCC");
		
    $("input.sbt").click(function() {
		f_RegisterEMail();
    })
});
var slideX={
	thisUl:$('#catalog ul.imgbox'),
	btnLeft:$('#catalog a.left'),
	btnRight:$('#catalog a.right'),
	thisLi:$('#catalog ul.imgbox li'),
	init:function(){
		slideX.thisUl.width(slideX.thisLi.length*119);
		slideX.slideAuto();
		slideX.btnLeft.click(slideX.slideLeft).hover(slideX.slideStop,slideX.slideAuto);
		slideX.btnRight.click(slideX.slideRight).hover(slideX.slideStop,slideX.slideAuto);
		slideX.thisUl.hover(slideX.slideStop,slideX.slideAuto);
		},
	slideLeft:function(){
		slideX.btnLeft.unbind('click',slideX.slideLeft);
		slideX.thisUl.find('li:last').prependTo(slideX.thisUl);
		slideX.thisUl.css('marginLeft',-119);
		slideX.thisUl.animate({'marginLeft':0},350,function(){
			slideX.btnLeft.bind('click',slideX.slideLeft);
			});
		return false;
		},
	slideRight:function(){
		slideX.btnRight.unbind('click',slideX.slideRight);
		slideX.thisUl.animate({'marginLeft':-119},350,function(){
			slideX.thisUl.css('marginLeft','0');
			slideX.thisUl.find('li:first').appendTo(slideX.thisUl);
			slideX.btnRight.bind('click',slideX.slideRight);
			});
		return false;
		},
	slideAuto:function(){
		slideX.intervalId=window.setInterval(slideX.slideRight,3000);
		},
	slideStop:function(){
		window.clearInterval(slideX.intervalId);
		}
	}
var slideTxt={
	thisBox:$('.Promotions .pbox'),
	btnLeft:$('.Promotions a.left'),
	btnRight:$('.Promotions a.right'),
	thisEle:$('.Promotions .pbox ul'),
	init:function(){
		slideTxt.thisBox.width(slideTxt.thisEle.length*238);
		slideTxt.slideAuto();
		slideTxt.btnLeft.click(slideTxt.slideLeft).hover(slideTxt.slideStop,slideTxt.slideAuto);
		slideTxt.btnRight.click(slideTxt.slideRight).hover(slideTxt.slideStop,slideTxt.slideAuto);
		slideTxt.thisBox.hover(slideTxt.slideStop,slideTxt.slideAuto);
		},
	slideLeft:function(){
		slideTxt.btnLeft.unbind('click',slideTxt.slideLeft);
		slideTxt.thisBox.find('ul:last').prependTo(slideTxt.thisBox);
		slideTxt.thisBox.css('marginLeft',-238);
		slideTxt.thisBox.animate({'marginLeft':0},350,function(){
			slideTxt.btnLeft.bind('click',slideTxt.slideLeft);
			});
		return false;
		},
	slideRight:function(){
		slideTxt.btnRight.unbind('click',slideTxt.slideRight);
		slideTxt.thisBox.animate({'marginLeft':-238},350,function(){
			slideTxt.thisBox.css('marginLeft','0');
			slideTxt.thisBox.find('ul:first').appendTo(slideTxt.thisBox);
			slideTxt.btnRight.bind('click',slideTxt.slideRight);
			});
		return false;
		},
	slideAuto:function(){
		slideTxt.intervalId=window.setInterval(slideTxt.slideRight,5000);
		},
	slideStop:function(){
		window.clearInterval(slideTxt.intervalId);
		}
	}

//商品分类hover效果
$('div.hcatabox').hover(function(){
	$(this).addClass('hover');
	},function(){$(this).removeClass('hover')});
//	
//首页弹窗
