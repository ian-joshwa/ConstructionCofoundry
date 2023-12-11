//images reveal
let revealContainers = document.querySelectorAll(".img-reveal");
revealContainers.forEach((container) => {
  let image = container.querySelector("img");
  let tl = gsap.timeline({
	scrollTrigger: {
	  trigger: image,
	  toggleActions: "restart none none reset"
	}
  });
  tl.set(container, { autoAlpha: 1 });
  if(container.classList.contains("reveal-left")) {
  tl.from(container, 1.5, {
	xPercent: -100,
	ease: Power2.out,
  });
  tl.from(image, 1.5, {
	xPercent: 100,
	scale: 1.2,
	delay: -1.5,
	ease: Power2.out
  });
  } else if(container.classList.contains("reveal-right")) {
  tl.from(container, 1.5, {
	xPercent: 100,
	ease: Power2.out,
  });
  tl.from(image, 1.5, {
	xPercent: -100,
	scale: 1.2,
	delay: -1.5,
	ease: Power2.out
  });
   } else if(container.classList.contains("reveal-bottom")) {
  tl.from(container, 1.5, {
	yPercent: 100,
	ease: Power2.out,
  });
  tl.from(image, 1.5, {
	yPercent: -100,
	scale: 1.2,
	delay: -1.5,
	ease: Power2.out
  });	  
  } else if(container.classList.contains("reveal-top")) {
	tl.from(container, 1.5, {
	  yPercent: -100,
	  ease: Power2.out,
	});
	tl.from(image, 1.5, {
	  yPercent: 100,
	  scale: 1.2,
	  delay: -1.5,
	  ease: Power2.out
	});	  
	} else if(container.classList.contains("reveal-zoom")) {

		tl.from(image, 1.5, {
		  yPercent: 100,
		  scale: 1.5,
		  delay: -1.5,
		  ease: Power2.out
		});	   
  } else {
   tl.to(container, 1.5, {
	//yPercent: 100,
	left: '7.5%',
	width:'85%',
	ease: Power2.out,
  });
  tl.from(image, 1.5, {
	//yPercent: -100,
	scale: 1,
	delay: -1.5,
	ease: Power2.out
  });
  }  
});
//animation scroll	
function animateFrom(elem, direction) {
  direction = direction | 1;
  
  var x = 0,
	  y = direction * 100;
  if(elem.classList.contains("reveal-left")) {
	x = -100;
	y = 0;
  } else if(elem.classList.contains("reveal-right")) {
	x = 100;
	y = 0;
  }
  gsap.fromTo(elem, {x: x, y: y, autoAlpha: 0}, {
	duration: 4, 
	x: 0,
	y: 0, 
	autoAlpha: 1, 
	ease: "expo", 
	overwrite: "auto"
  });
}
function hide(elem) {
  gsap.set(elem, {autoAlpha: 0});
} 

document.addEventListener("DOMContentLoaded", function() {
 
  console.log('DOM fully loaded and parsed');
  
  gsap.utils.toArray(".reveal").forEach(function(elem) {
	hide(elem); // assure that the element is hidden when scrolled into view
	
	ScrollTrigger.create({
	  trigger: elem,
	  onEnter: function() { animateFrom(elem) }, 
	  onEnterBack: function() { animateFrom(elem, -1) },
	  onLeave: function() { hide(elem) } // assure that the element is hidden when scrolled into view
	});
  });
  
  
	gsap.utils.toArray("#project_images img").forEach(function(elem) {
	hide(elem); // assure that the element is hidden when scrolled into view
	
	ScrollTrigger.create({
	  trigger: elem,
	  onEnter: function() { animateFrom(elem) }, 
	  onEnterBack: function() { animateFrom(elem, -1) },
	  onLeave: function() { hide(elem) } // assure that the element is hidden when scrolled into view
	});
  });
  
  
});
