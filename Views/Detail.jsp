<%-- 
    Document   : Detail
    Created on : Dec 29, 2020, 5:43:04 PM
    Author     : trinh
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
         <link href="css/style.css" rel="stylesheet" type="text/css"/>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">  

        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">       
         <style>
            .checked {
              color: orange;
            }             
            .gallery-wrap .img-big-wrap img {
                height: 450px;
                width: auto;
                display: inline-block;
                cursor: zoom-in;
            }


            .gallery-wrap .img-small-wrap .item-gallery {
                width: 60px;
                height: 60px;
                border: 1px solid #ddd;
                margin: 7px 2px;
                display: inline-block;
                overflow: hidden;
            }

            .gallery-wrap .img-small-wrap {
                text-align: center;
            }
            .gallery-wrap .img-small-wrap img {
                max-width: 100%;
                max-height: 100%;
                object-fit: cover;
                border-radius: 4px;
                cursor: zoom-in;
            }
            .img-big-wrap img{
                width: 100% !important;
                height: auto !important;
            }
        </style>
    </head>
    <body>
        <jsp:include page="Menu.jsp"></jsp:include>
            <div class="container">
                <div class="row">
                <jsp:include page="Left.jsp"></jsp:include>
                    
                <div class="col-sm-9">
                    <div class="container">
                        <div class="card">
                            <div class="row">
                                <aside class="col-sm-5 border-right">
                                    <article class="gallery-wrap"> 
                                        <div class="img-big-wrap">
                                            <div> <a href="#"><img src="${detail.image}"></a></div>
                                        </div> <!-- slider-product.// -->
                                        <div class="img-small-wrap">
                                        </div> <!-- slider-nav.// -->
                                    </article> <!-- gallery-wrap .end// -->
                                </aside>
                                <aside class="col-sm-7">
                                    <article class="card-body p-5">
                                        <h3 class="title mb-3">${detail.name}</h3>

                                        <p class="price-detail-wrap"> 
                                            <span class="price h3 text-warning"> 
                                                <span class="currency">US $</span><span class="num">${detail.price}</span>
                                            </span> 
                                            <!--<span>/per kg</span>--> 
                                        </p> <!-- price-detail-wrap .// -->
                                        <dl class="item-property">
                                            <dt>Description</dt>
                                            <dd><p>${detail.description} </p></dd>
                                        </dl>
<!--                                        <dl class="param param-feature">
                                            <dt>Model#</dt>
                                            <dd>12345611</dd>
                                        </dl>   item-property-hor .// 
                                        <dl class="param param-feature">
                                            <dt>Color</dt>
                                            <dd>Black and white</dd>
                                        </dl>   item-property-hor .// 
                                        <dl class="param param-feature">
                                            <dt>Delivery</dt>
                                            <dd>Russia, USA, and Europe</dd>
                                        </dl>   item-property-hor .// -->

                                        <hr>
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <dl class="param param-inline">
                                                    <dt>Xuất xứ: ${detail.from}</dt>
                                                    <dt>Dung tích: ${detail.dungtich}</dt>
                                                    <dt>Ðánh giá:</dt>
                                                    <dd>
                                                            <c:choose>  
                                                                <c:when test="${averageStar>=4.5}">
                                                                    <p class="card-text">
                                                                        <span class="fa fa-star checked"></span>                   
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star checked"></span>
                                                                        </p>
                                                                </c:when>  
                                                                <c:when test="${averageStar>=3.5}"> 
                                                                    <p class="card-text">
                                                                        <span class="fa fa-star checked"></span>                   
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star"></span>
                                                                        </p>
                                                                </c:when>
                                                                <c:when test="${averageStar>=2.5}">  
                                                                    <p class="card-text">
                                                                        <span class="fa fa-star checked"></span>                   
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star"></span>
                                                                        </p>
                                                                </c:when>
                                                                <c:when test="${averageStar>=1.5}">  
                                                                    <p class="card-text">
                                                                        <span class="fa fa-star checked"></span>                   
                                                                        <span class="fa fa-star checked"></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star"></span>
                                                                        </p>
                                                                </c:when>
                                                                <c:when test="${averageStar>0}">  
                                                                    <p class="card-text">
                                                                        <span class="fa fa-star checked"></span>                   
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star"></span>
                                                                        </p>
                                                                </c:when>                                                    
                                                                <c:otherwise>  
                                                                    <p class="card-text">
                                                                        <span class="fa fa-star "></span>                   
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star "></span>
                                                                        <span class="fa fa-star "></span>

                                                                        </p>
                                                                </c:otherwise>  
                                                            </c:choose>                                                        
                                                    </dt>
                                                </dd>    
                                                    
                                                    
                                                </dl>  <!-- item-property .// -->
                                            </div> <!-- col.// -->
                                            
                                        </div> <!-- row.// -->
                                        <hr>
<!--                                        <a href="https://shopee.vn/%F0%9D%90%8C%F0%9D%90%9A%CC%82%CC%83%F0%9D%90%AE-%F0%9D%90%AD%F0%9D%90%A1%F0%9D%90%AE%CC%9B%CC%89-N%C6%B0%E1%BB%9Bc-hoa-nam-%F0%9D%97%97%F0%9D%97%B6.%F0%9D%97%BC%F0%9D%97%BF-%F0%9D%90%92%F0%9D%90%9A%F0%9D%90%AE%F0%9D%90%AF%F0%9D%90%9A%F0%9D%90%A0%F0%9D%90%9E-%F0%9D%90%84%F0%9D%90%83%F0%9D%90%93-Ch%C3%ADnh-H%C3%A3ng-Th%C6%A1m-L%C3%A2u-8H-B%E1%BA%A3o-H%C3%A0nh-%C4%90%E1%BA%BFn-Gi%E1%BB%8Dt-Cu%E1%BB%91i-i.156564125.18141331077?sp_atk=bac44b62-2289-4a34-9a1e-03508210e924&xptdk=bac44b62-2289-4a34-9a1e-03508210e924" class="btn btn-lg btn-primary text-uppercase"> Buy now </a>-->
<!--                                        <a href="#" class="btn btn-lg btn-outline-primary text-uppercase"> <i class="fas fa-shopping-cart"></i> Add to cart </a>-->
                                    </article> <!-- card-body.// -->
                                </aside> <!-- col.// -->
                            </div> <!-- row.// -->
                        </div> <!-- card.// -->


                    </div>
                    <jsp:include page="Review.jsp"></jsp:include>                                                     
                </div>
            </div>
                                                                                           
        </div>
                                                    
                                                    
        <!-- Footer -->
        <footer class="text-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-lg-4 col-xl-3">
                        <h5>About</h5>
                        <hr class="bg-white mb-2 mt-0 d-inline-block mx-auto w-25">
                        <p class="mb-0">
                            Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression.
                        </p>
                    </div>

                    <div class="col-md-2 col-lg-2 col-xl-2 mx-auto">
                        <h5>Informations</h5>
                        <hr class="bg-white mb-2 mt-0 d-inline-block mx-auto w-25">
                        <ul class="list-unstyled">
                            <li><a href="">Link 1</a></li>
                            <li><a href="">Link 2</a></li>
                            <li><a href="">Link 3</a></li>
                            <li><a href="">Link 4</a></li>
                        </ul>
                    </div>

                    <div class="col-md-3 col-lg-2 col-xl-2 mx-auto">
                        <h5>Others links</h5>
                        <hr class="bg-white mb-2 mt-0 d-inline-block mx-auto w-25">
                        <ul class="list-unstyled">
                            <li><a href="">Link 1</a></li>
                            <li><a href="">Link 2</a></li>
                            <li><a href="">Link 3</a></li>
                            <li><a href="">Link 4</a></li>
                        </ul>
                    </div>

                    <div class="col-md-4 col-lg-3 col-xl-3">
                        <h5>Contact</h5>
                        <hr class="bg-white mb-2 mt-0 d-inline-block mx-auto w-25">
                        <ul class="list-unstyled">
                            <li><i class="fa fa-home mr-2"></i> My company</li>
                            <li><i class="fa fa-envelope mr-2"></i> email@example.com</li>
                            <li><i class="fa fa-phone mr-2"></i> + 33 12 14 15 16</li>
                            <li><i class="fa fa-print mr-2"></i> + 33 12 14 15 16</li>
                        </ul>
                    </div>
                    <div class="col-12 copyright mt-3">
                        <p class="float-left">
                            <a href="#">Back to top</a>
                        </p>
                        <p class="text-right text-muted">created with <i class="fa fa-heart"></i> by <a href="https://t-php.fr/43-theme-ecommerce-bootstrap-4.html"><i>t-php</i></a> | <span>v. 1.0</span></p>
                    </div>
                </div>
            </div>
        </footer>
    </body>
</html>
