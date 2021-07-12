function NavbarVM() {
    var self = this;
    self.isOpen = ko.observable(false);

    self.toggleMenu = function() {
        self.isOpen(!self.isOpen());
    };
}
ko.applyBindings(new NavbarVM(), document.querySelector("#main-nav"));


var myCommentTemplate = `
<article class="my-post-comments">
    <ul data-bind="foreach: commentList">
        <li class="my-post-comments-item">
            <h4 data-bind="text: name"></h5>
            <h5 data-bind="text: email"></h6>
            <p data-bind="text: body"></p>
            <hr />
        </li>
    </ul>
</article>`;

function CommentVM(params) {
    var self = this;
    self.postId = params.postId;
    self.commentList = ko.observableArray([]);

    // I'm using fetch but you should be able to use ajax instead
    fetch("https://jsonplaceholder.typicode.com/comments?postId=" + self.postId)
        .then(function(response) {
            if (!response.ok) throw new Error(response.statusText);
            return response.json();
        })
        .then(function(comments) {
            comments.forEach(function(comment) {
                // if you won't make changes to the elements
                // don't use observables, just push the items without view models or observables
                self.commentList.push(comment);
            });
        })
        .catch(function(error) {
            console.warn(error.message);
        });
}


ko.components.register('my-post-comments', {
    template: myCommentTemplate,
    viewModel: CommentVM
});
