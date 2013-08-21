<?php
  register_sidebar(array(
    'name' => __( 'Home Right Sidebar' ),
    'id' => 'home-right-sidebar',
    'description' => __( 'Home Page Right Sidebar' ),
    'before_title' => '<h2>',
    'after_title' => '</h2>',
    'before_widget' => '<div id="%1$s" class="widget subnav %2$s">',
    'after_widget' => '</div>'
  ));
  
?>
