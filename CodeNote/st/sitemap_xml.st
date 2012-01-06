<?xml version="1.0" encoding="UTF-8"?>
<?xml-stylesheet type="text/xsl" href="/sitemap.xsl"?>
<urlset xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
        xsi:schemaLocation="http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd" 
        xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>$domain$/</loc>
    <lastmod>$date$</lastmod>
    <changefreq>daily</changefreq>
    <priority>1.0</priority>
  </url>
  
  $list:{<url><loc>$baseurl$$it.Url$</loc><lastmod>$it.W3CDTF$</lastmod><changefreq>monthly</changefreq><priority>0.2</priority></url>}$
  
</urlset>