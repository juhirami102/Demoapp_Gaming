
    (function () {    
      'use strict';
      // ------------------------------------------------------- //
      // Calendar
      // ------------------------------------------------------ //
      jQuery(function() {
        // page is ready
        jQuery('#calendar').fullCalendar({
              themeSystem: 'bootstrap4',
              // emphasizes business hours
              businessHours: false,
              defaultView: 'month',
              // event dragging & resizing
              editable: true,
              // header
              header: {
                  left: 'title',
                  //center: 'month,agendaWeek,agendaDay',
                  right: 'today prev,next'
              },
              events: [
                
              ],
              eventRender: function(event, element) {
                  if(event.icon){
                      element.find(".fc-title").prepend("<i class='icon icon-"+event.icon+"'></i>");
                  }
                },
              dayClick: function() {
                  jQuery('#modal-view-event-add').modal();
              },
              eventClick: function(event, jsEvent, view) {
                      jQuery('.event-icon').html("<i class='icon icon-"+event.icon+"'></i>");
                      jQuery('.event-title').html(event.title);
                      jQuery('.event-body').html(event.description);
                      
                      jQuery('.eventUrl').attr('href',event.url);
                      jQuery('#modal-view-event').modal();
              },
        })
          
        jQuery('#calendar2').fullCalendar({
            themeSystem: 'bootstrap4',
            // emphasizes business hours
            businessHours: false,
            defaultView: 'month',
            // event dragging & resizing
            editable: true,
            // header
            header: {
                left: 'title',
                center: 'month,agendaWeek,agendaDay',
                right: 'today prev,next'
            },
            events: [
              //   {
              //       title: 'Barber',
              //       description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
              //       start: '2019-09-07',
              //       end: '2019-09-07',
              //       className: 'fc-bg-default',
              //       icon : "circle"
              //   },
                {
                    title: 'Java Programming',
                    description: 'This is an Advance Java Programming Course.',
                    start: '2019-09-08T14:00:00',
                    end: '2019-09-08T20:00:00',
                    className: 'fc-bg-deepskyblue',
                    icon : "home",
                    allDay: false
                },
                {
                    title: 'PHP Programming',
                    description: 'This is An introduction to PHP Programming Course.',
                    start: '2019-09-10T13:00:00',
                    end: '2019-09-10T16:00:00',
                    className: 'fc-bg-pinkred',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Docker',
                    description: 'This is a course on Docker container technology.',
                    start: '2019-09-12',
                    className: 'fc-bg-lightgreen',
                    icon : "computer"
                },
                {
                    title: 'PMP Certification',
                    description: 'This is a course for PMP Certification.',
                    start: '2019-09-13',
                    end: '2019-09-13',
                    className: 'home',
                    icon : "home"
                },
                {
                  title: 'Introduction to IoT',
                  description: 'This is a course on Introduction to IoT.',
                  start: '2019-09-14',
                  end: '2019-09-14',
                  className: 'home',
                  icon : "computer"
              },
                {
                    title: 'Cloud Computing',
                    description: 'This is an Advance Cloud Computing Course.',
                    start: '2019-09-13',
                    end: '2019-09-14',
                    className: 'fc-bg-default',
                    icon : "computer"
                },
              //   {
              //       title: 'Birthday',
              //       description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
              //       start: '2019-09-13',
              //       end: '2019-09-14',
              //       className: 'fc-bg-default',
              //       icon : "user"
              //   },
              //   {
              //       title: 'Restaurant',
              //       description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
              //       start: '2019-09-15T09:30:00',
              //       end: '2019-09-15T11:45:00',
              //       className: 'fc-bg-default',
              //       icon : "user",
              //       allDay: false
              //   },
              //   {
              //       title: 'Dinner',
              //       description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
              //       start: '2019-09-15T20:00:00',
              //       end: '2019-09-15T22:30:00',
              //       className: 'fc-bg-default',
              //       icon : "user",
              //       allDay: false
              //   },
                {
                    title: 'Team Learning',
                    description: 'This is an Advance Team Learning Course',
                    start: '2019-09-25',
                    end: '2019-09-25',
                    className: 'user',
                    icon : "home"
                },
              //   {
              //       title: 'Go Space :)',
              //       description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
              //       start: '2019-09-27',
              //       end: '2019-09-27',
              //       className: 'fc-bg-default',
              //       icon : "user"
              //   },
              //   {
              //       title: 'Dentist',
              //       description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
              //       start: '2019-09-29T11:30:00',
              //       end: '2019-09-29T012:30:00',
              //       className: 'fc-bg-blue',
              //       icon : "user",
              //       allDay: false
              //   }
            ],
            eventRender: function(event, element) {
                if(event.icon){
                    element.find(".fc-title").prepend("<i class='icon icon-"+event.icon+"'></i>");
                }
              },
            dayClick: function() {
                jQuery('#modal-view-event-add').modal();
            },
            eventClick: function(event, jsEvent, view) {
                    jQuery('.event-icon').html("<i class='icon icon-"+event.icon+"'></i>");
                    jQuery('.event-title').html(event.title);
                    jQuery('.event-body').html(event.description);
                    
                    jQuery('.eventUrl').attr('href',event.url);
                    jQuery('#modal-view-event').modal();
            },
        })
        
        jQuery('.calendarDepartment').fullCalendar({
            themeSystem: 'bootstrap4',
            // emphasizes business hours
            businessHours: false,
            defaultView: 'month',
            // event dragging & resizing
            editable: true,
            // header
            header: {
                left: 'title',
                center: 'month,agendaWeek,agendaDay',
                right: 'today prev,next'
            },
            events: [
                {
                    title: 'Sales',
                    description: 'This is an Advance Java Programming Course.',
                    start: '2019-09-22T14:00:00',
                    end: '2019-09-23T20:00:00',
                    className: 'fc-bg-deepskyblue',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Marketing',
                    description: 'This is An introduction to PHP Programming Course.',
                    start: '2019-09-10T13:00:00',
                    end: '2019-09-10T16:00:00',
                    className: 'fc-bg-pinkred',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Development',
                    description: 'This is a course on Docker container technology.',
                    start: '2019-09-12',
                    className: 'fc-bg-lightgreen',
                    icon : "computer"
                },
                {
                    title: 'HR',
                    description: 'This is a course for PMP Certification.',
                    start: '2019-09-30',
                    end: '2019-10-5',
                    className: 'home',
                    icon : "hr"
                },
                {
                    title: 'Support',
                    description: 'This is a course on Introduction to IoT.',
                    start: '2019-09-27',
                    end: '2019-10-05',
                    className: 'home',
                    icon : "support"
                }
            ],
            eventRender: function(event, element) {
                if(event.icon){
                    element.find(".fc-title").prepend("<i class='icon icon-"+event.icon+"'></i>");
                }
            },
            dayClick: function() {
                jQuery('#modal-view-event-add').modal();
            },
            eventClick: function(event, jsEvent, view) {
                jQuery('.event-icon').html("<i class='icon icon-"+event.icon+"'></i>");
                jQuery('.event-title').html(event.title);
                jQuery('.event-body').html(event.description);
                
                jQuery('.eventUrl').attr('href',event.url);
                jQuery('#modal-view-event').modal();
            },
        })
        
        jQuery('#calendarTrainer').fullCalendar({
            themeSystem: 'bootstrap4',
            // emphasizes business hours
            businessHours: false,
            defaultView: 'month',
            // event dragging & resizing
            editable: true,
            // header
            header: {
                left: 'title',
                center: 'month,agendaWeek,agendaDay',
                right: 'today prev,next'
            },
            events: [
                {
                    title: 'Sales - Sales GuideLines',
                    description: 'This is an Advance Java Programming Course.',
                    start: '2019-09-22T14:00:00',
                    end: '2019-09-25T20:00:00',
                    className: 'fc-bg-deepskyblue',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Marketing - Sales GuideLines',
                    description: 'This is An introduction to PHP Programming Course.',
                    start: '2019-09-10T13:00:00',
                    end: '2019-09-14T16:00:00',
                    className: 'fc-bg-pinkred',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Development - Java Programming',
                    description: 'This is a course on Docker container technology.',
                    start: '2019-09-12',
                    end: '2019-09-15',
                    className: 'fc-bg-lightgreen',
                    icon : "computer"
                },
                {
                    title: 'HR - Sales GuideLines',
                    description: 'This is a course for PMP Certification.',
                    start: '2019-09-30',
                    end: '2019-10-5',
                    className: 'home',
                    icon : "hr"
                },
                {
                    title: 'Support - .NET Programming',
                    description: 'This is a course on Introduction to IoT.',
                    start: '2019-09-27',
                    end: '2019-10-05',
                    className: 'home',
                    icon : "support"
                }
            ],
            eventRender: function(event, element) {
                if(event.icon){
                    element.find(".fc-title").prepend("<i class='icon icon-"+event.icon+"'></i>");
                }
            },
            dayClick: function() {
                jQuery('#modal-view-event-add').modal();
            },
            eventClick: function(event, jsEvent, view) {
                jQuery('.event-icon').html("<i class='icon icon-"+event.icon+"'></i>");
                jQuery('.event-title').html(event.title);
                jQuery('.event-body').html(event.description);
                
                jQuery('.eventUrl').attr('href',event.url);
                jQuery('#modal-view-event').modal();
            },
        })
        
        jQuery('#calendarTrainningCenter').fullCalendar({
            themeSystem: 'bootstrap4',
            // emphasizes business hours
            businessHours: false,
            defaultView: 'month',
            // event dragging & resizing
            editable: true,
            // header
            header: {
                left: 'title',
                center: 'month,agendaWeek,agendaDay',
                right: 'today prev,next'
            },
            events: [
                {
                    title: 'Sales - Sales GuideLines',
                    description: 'This is an Advance Java Programming Course.',
                    start: '2019-09-22T14:00:00',
                    end: '2019-09-25T20:00:00',
                    className: 'fc-bg-deepskyblue',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Marketing - Sales GuideLines',
                    description: 'This is An introduction to PHP Programming Course.',
                    start: '2019-09-10T13:00:00',
                    end: '2019-09-14T16:00:00',
                    className: 'fc-bg-pinkred',
                    icon : "computer",
                    allDay: false
                },
                {
                    title: 'Development - Java Programming',
                    description: 'This is a course on Docker container technology.',
                    start: '2019-09-12',
                    end: '2019-09-15',
                    className: 'fc-bg-lightgreen',
                    icon : "computer"
                },
                {
                    title: 'HR - Sales GuideLines',
                    description: 'This is a course for PMP Certification.',
                    start: '2019-09-30',
                    end: '2019-10-5',
                    className: 'home',
                    icon : "hr"
                },
                {
                    title: 'Support - .NET Programming',
                    description: 'This is a course on Introduction to IoT.',
                    start: '2019-09-27',
                    end: '2019-10-05',
                    className: 'home',
                    icon : "support"
                }
            ],
            eventRender: function(event, element) {
                if(event.icon){
                    element.find(".fc-title").prepend("<i class='icon icon-"+event.icon+"'></i>");
                }
            },
            dayClick: function() {
                jQuery('#modal-view-event-add').modal();
            },
            eventClick: function(event, jsEvent, view) {
                jQuery('.event-icon').html("<i class='icon icon-"+event.icon+"'></i>");
                jQuery('.event-title').html(event.title);
                jQuery('.event-body').html(event.description);
                
                jQuery('.eventUrl').attr('href',event.url);
                jQuery('#modal-view-event').modal();
            },
        })
        
      });
    
  })(jQuery);