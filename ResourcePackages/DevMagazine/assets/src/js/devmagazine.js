$(document).ready(function() {
	// Makes the navigation fixed
	$(".js-nav-fixed").fixit({
		top: 0,
		fixClass: "is-fixed",
		dummyClass: "fixed-dummy",
		classOnly: true,
		renderDummy: true
	});
	// Shows hidden articles and events
	$("a[data-role='show-more']").on('click', function(e) {
		console.log(5);
		e.preventDefault();
		$(this).hide();
		var hiddenItems = $('.hidden');
		hiddenItems.removeClass('hidden');
	});
	// Leads to Search.html --> simulates search logic
	$('.js-search-field').change(function() {
		location.href = "Search.html";
	});
});
