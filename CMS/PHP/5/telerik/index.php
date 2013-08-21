<!DOCTYPE HTML>
<html>

<head>
  <title>CSS3_B&W</title>
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  <link rel="stylesheet" type="text/css" href="<?php bloginfo('stylesheet_url') ?>" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="js/modernizr-1.5.min.js"></script>
</head>

<body>
  <div id="main">
    <?php get_header(); ?>
    <div id="site_content">
      <ul id="images">
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/1.jpg" width="600" height="300" alt="photo_one" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/2.jpg" width="600" height="300" alt="photo_two" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/3.jpg" width="600" height="300" alt="photo_three" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/4.jpg" width="600" height="300" alt="photo_four" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/5.jpg" width="600" height="300" alt="photo_five" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/6.jpg" width="600" height="300" alt="photo_six" /></li>
      </ul>
      <div id="sidebar_container">
      <?php if ( ! dynamic_sidebar( 'home-right-sidebar' ) ) : ?>
          <h3>Latest News</h3>
          <h4>New Website Launched</h4>
          <h5>January 1st, 2012</h5>
          <p>2012 sees the redesign of our website. Take a look around and let us know what you think.<br /><a href="#">Read more</a></p>
      <?php endif; ?>
      </div>
      <div id="content">
        <?php
        if(have_posts()):
          while(have_posts()):
            the_post();
        ?>

        <h1><a href="<?php the_permalink() ?>"><?php echo the_title(); ?></a></h1>
        <p><?php echo the_content(); ?></p>
        <p>Date: <a href="#"><?php echo the_date(); ?></a></p>
        <p>Author: <a href="#"><?php echo the_author(); ?></a></p>
        <p>Category: <a href="#"><?php echo the_category(); ?></a></p>
        <?php
          endwhile;
        endif;
        ?>
      </div>
    </div>
    <?php get_footer(); ?>
  </div>
  <!-- javascript at the bottom for fast page loading -->
  <script type="text/javascript" src="js/jquery.min.js"></script>
  <script type="text/javascript" src="js/jquery.easing.min.js"></script>
  <script type="text/javascript" src="js/jquery.lavalamp.min.js"></script>
  <script type="text/javascript" src="js/jquery.kwicks-1.5.1.js"></script>
  <script type="text/javascript">
    $(document).ready(function() {
      $('#images').kwicks({
        max : 600,
        spacing : 2
      });
    });
  </script>
  <script type="text/javascript">
    $(function() {
      $("#lava_menu").lavaLamp({
        fx: "backout",
        speed: 700
      });
    });
  </script>
</body>
</html>
