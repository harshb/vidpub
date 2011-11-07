
Production = Backbone.Model.extend({
    //primary key
    idAttribute: "ID",

    //create or edit
    //if I did not specify url here, bb would follow a restful convention for urls
    //post : "/productions"
    //put & delete : "/productions/1"
    url: function () {

        return this.isNew() ? "/api/productions/create" : "/api/productions/edit/" + this.get("ID");

       
    }
});


Productions = Backbone.Collection.extend({
    model: Production,
    url: "/api/productions"
});


productions = new Productions();

//for index functionality
ListView = Backbone.View.extend({

    initialize: function () {

        //scope of "this" is currentview for render mmethod
        _.bindAll(this, 'render');
        this.template = $("#listTemplate");

        //reset,add,remove events are built into bb
        //reset fired whenever data is pushed into collection
        this.collection.bind("reset", this.render);


    },
    events: {

        "click .production-link": "showForm",
        "click #new-production": "showCreate"
    },

    showCreate: function () {
 
        app.navigate("create", true);
        return false;
    },
    showForm: function (evt) {

        //get the id that was clicked
        var id = $(evt.currentTarget).data('production-id');

        //navigate
        app.navigate("edit/" + id, true);
        return false;

    },
    render: function () {

        var data = { items: this.collection.toJSON() };
        var html = this.template.tmpl(data);
        $(this.el).html(html);

        return this;
    },

    //thanks to: derik bailey's backbone.modelbinding.min.js
    close: function () {
        this.remove();
        this.unbind();
        
    }

});

//for crud functionality
FormView = Backbone.View.extend({

    initialize: function () {

        //scope of this is this view for mentioned methods
        _.bindAll(this, 'render');
        this.template = $("#productionFormTemplate");
        

    },
    events: {

        // "change input": "updateModel",
        "submit #productionForm": "save"
    },


    save: function () {

        this.model.save(

        this.model.attributes,
            {
                success: function (model, response) {
                    alert(model.get("Title") + " saved...");
                    //hb force refresh
                    // window.location.reload(true);
                    productions.fetch();
                },
                error: function (model, response) {
                    alert("sorry");
                }
            }

        );

        return false;
    },

    //model binding
    /*
    updateModel: function (evt) {

    var field = $(evt.currentTarget);
    var data = {};
    //json object
    data[field.attr('ID')] = field.val();
    this.model.set(data);

    },
    */
    /*
    updateModel: function (evt) {
        var field = $(evt.currentTarget);
        var data = {};
        var key = field.attr('ID');
        var val = field.val();
        data[key] = val;
        if (!this.model.set(data)) {
            //reset the form field
            field.val(this.model.get(key));
        }
    },
    */

    //combo
    fillCombo: function () {

        $.getJSON("/api/productions/authors", function (data) {
            //alert(data.length);
            var theauthor = formView.model.get("Author");

            
            var items = "<option selected " + theauthor + ">" +  theauthor + "</option>";
            $.each(data, function (i, item) {
                items += "<option value='" + item.Value + "'>" + item.Text + "</option>";
            });
            $("#AuthorCombo").html(items);

            //set selected
            $("#AuthorCombo").val(theauthor);

        });

    },
    render: function () {

        var html = this.template.tmpl(this.model.toJSON());
        $(this.el).html(html);
        this.$(".datepicker").datepicker();

        //combo
        this.fillCombo();


        // execute the model bindings
        //thanks to: derik bailey's backbone.modelbinding.min.js
        Backbone.ModelBinding.bind(this);
        return this;
    },
    //thanks to: derik bailey's backbone.modelbinding.min.js
    close: function () {
        this.remove();
        this.unbind();
        Backbone.ModelBinding.unbind(this);
    }

});


var ProductionAdmin = Backbone.Router.extend({

    initialize: function () {
        //listview is instanciated with empty collection, and el is specified
        listView = new ListView({ collection: productions, el: "#production-list" });

        //instantiate edit view
        formView = new FormView({ el: "#production-form" });

    },
    routes: {
        "": "index", //default route
        "edit/:id": "edit",
        "create": "create"
    },

    index: function () {
        listView.render();
    },
    edit: function (id) {

        listView.render();
        //clear out form by clearing el
        $(formView.el).empty();

        //by default bb expects a lowervcase id as the identifier
        //set idAttribute on model
        var model = productions.get(id);
        formView.model = model;
        formView.render();

    },

    create: function (id) {
    
        var model = new Production();
        listView.render();
        $(formView.el).empty();
        formView.model = model;
        formView.render();

    }

});

jQuery(function () {


    // var listView = new ListView({ collection: productions });

    // $("#production-list").html(listView.render().el);



    
    //fetch is called, on completion of which reset event is triggered which in
    //turn triggers render of listview. Render will then push the templated html
    //into el and user sees html
    productions.fetch({

        success: function () {

            //create the router
            window.app = new ProductionAdmin();
            Backbone.history.start();

        },
        error: function () {

        }

    });
});



//You can trigger reset manually at console
//productions.reset ([{Title:"One"},{Title: "Two"}])

//you can check route in the console:
//app.navigate("edit/1", true)
//false will change url but not navigate
//this will give a url like /vidpub/productions#edit/1 -- can be bookmarked and 
//user can navigate back



