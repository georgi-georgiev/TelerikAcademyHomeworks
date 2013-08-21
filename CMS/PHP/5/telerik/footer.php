	<footer>
      <p><a href="index.html">home</a> | <a href="about.html">about me</a> | <a href="portfolio.html">my portfolio</a> | <a href="blog.html">blog</a> | <a href="contact.php">contact</a></p>
      <p>&copy; 2012 CSS3_B&W. All Rights Reserved. | <a href="http://www.css3templates.co.uk">design from css3templates.co.uk</a></p>
    </footer>
    </div>
  <!-- javascript at the bottom for fast page loading -->
  <script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>js/jquery.min.js"></script>
  <script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>js/jquery.easing.min.js"></script>
  <script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>js/jquery.lavalamp.min.js"></script>
  <script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>js/jquery.kwicks-1.5.1.js"></script>
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