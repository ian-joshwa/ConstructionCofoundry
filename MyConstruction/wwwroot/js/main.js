
jQuery( "#menu_btn" ).click(function() {
  jQuery( "body" ).addClass( "noScroll" )
});
jQuery( "#close_btn" ).click(function() {
	  jQuery( "body" ).removeClass( "noScroll" )
});

(function($){
$(window).on('load resize', function () {
	
//custom vh height 
// First we get the viewport height and we multiple it by 1% to get a value for a vh unit
let vh = window.innerHeight * 0.01;
// Then we set the value in the --vh custom property to the root of the document
document.documentElement.style.setProperty('--vh', `${vh}px`);

}); 
})(jQuery);

//modal menu

var tlmenu = new TimelineMax({paused:true});

tlmenu.to ('#main_menu', 0.5, {
	autoAlpha: 1,
	left: 0,
	opacity: 1,
	zIndex: 999999
})
.fromTo ('#main_menu .appear ', 1, {
	y: 100, 
	opacity:0,
},
{
	y:0,
	opacity: 1,
})
;


jQuery('#menu_btn a').click(function(){
tlmenu.play(0)
});

jQuery('#close_btn a').click(function(){
tlmenu.reverse(0)
});


/* Adding / Removing Classes */
jQuery('.project_item-title h2').addClass('sm-title mb-0');
jQuery('#contact_submit').removeClass('btn-primary');
jQuery('#who-content a').addClass('white_btn')

/* Page Title */
//jQuery('#content .article-title').appendTo('#page_title');
//jQuery('#content .category-title').appendTo('#page_title');
//jQuery('#userForm > .md-title').appendTo('#page_title');
jQuery('#content .grid-item.grid-item-width100').append('<div class="clr"></div>');


/* Fit Text Header */
jQuery("#approach_img .title").fitText(1.125);

/* Slideshow Hover */
jQuery("#slideshow, #header .row").hover(
  function () {
    jQuery('.cursor').addClass('xl');
  }, 
  function () {
    jQuery('.cursor').removeClass('xl');
  }
);


(function($){

//Height of image
$(window).on('load resize', function () {
	
if (window.innerWidth >= 991) {

var maxHeight = 0;
jQuery(".field_details").each(function(){
   if (jQuery(this).height() > maxHeight) { maxHeight = jQuery(this).height(); }
});
jQuery(".field_details").height(maxHeight);
	
}

if (window.innerWidth >= 768) {

var divHeight = $('.approach-left').height(); 
$('#approach_img .custom').css('min-height', divHeight+200+'px');

}
if (window.innerWidth < 768 & window.innerWidth > 576) {

	var divHeight = $('.approach-left').height(); 
	$('#approach_img .custom').css('min-height', divHeight+'px');
	
}
if (window.innerWidth > 576) {
	//height of article image
		var divHeight = $('.autosize-content').height(); 
		$('.autosize-image').css('height', divHeight+'px');
	
	
	
	//height of article image
	$(window).on('load resize', function () {
		var divHeight = $('.autosize-content').height(); 
		$('.max-image').css('max-height', divHeight+'px');
	});
	
	//height of article image
	$(window).on('load resize', function () {
		var divHeight = $('.why-content').height(); 
		$('.why-image').css('height', divHeight+'px');
	}); 
	
	
	//height of article image
	$(window).on('load resize', function () {
		var divHeight = $('.phy-content').height(); 
		$('.phy-image').css('height', divHeight/2+'px');
	});
	
}
	
}); 



})(jQuery);
 
 
 
 
 /* Midnight Logo */
 
 
 jQuery(function($) {
 
	 var $nav = $('#menu_btn');
	 var $win = $(window);
	 var $sec = $('#slideshow');
	 var winH = $sec.height();   // Get the window height.
	 $win.on("scroll", function () {
		 if ($(this).scrollTop() > winH ) {
			 $nav.addClass("fixedmenu");
			 $nav.removeClass("absolutemenu");
			 jQuery('#menu_btn.fixedmenu').midnight();
		 } else {
			 $nav.removeClass("fixedmenu");
			 $nav.addClass("absolutemenu");
 
 
		 }
	 }).on("resize", function(){ // If the user resizes the window
	 var winH = $sec.height();   // Get the window height.
	 });
 
 });
 
 //Scroll to top
 
 jQuery(function($) {
$(window).on('load resize', function () {
 
	 var $back = $('#back-top');
	 var $outer = $('.outer-height');
	 var $win = $(window);
	 var winH = $outer.height();   // Get the window height.
	 
 
	 $win.on("scroll", function () {
		 if ($(this).scrollTop() > winH*1.4 ) {
			 $back.addClass("fixedBack");
		 } else {
			 $back.removeClass("fixedBack");
 
 
		 }
	 }).on("resize", function(){ // If the user resizes the window
		winH = $(this).height(); // you'll need the new height value
	 });
 
 });
 });
 
 
//slideshow 
 jQuery(document).ready(function(){
	 jQuery("#slideshow-carousel .owl-carousel").owlCarousel({
		 loop: true,
		 margin: 0,
		 nav: false,
		 autoplay: true,
		 autoplayTimeout: 3000,
		 autoplayHoverPause: false,
		 animateOut: 'fadeOut',
		 animateIn: 'fadeIn',
		 dots: false,
		 items: 1,
		 
	 });
 });
 

