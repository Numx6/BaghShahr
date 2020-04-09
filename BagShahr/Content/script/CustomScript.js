$('.owl-carousel').owlCarousel({
	autoplay: true,
	autoplayTimeout: 2000,
	margin: 10,
	autoplayHoverPause: true,
	loop: true,
	rtl: true,
	responsive: {
		0: {
			items: 1
		},
		768: {
			items: 2
		},
		992: {
			items: 3
		},
		1200: {
			items: 4
		}
	}
});
function changePage(pageId) {
	$("#pageId").val(pageId);
};
