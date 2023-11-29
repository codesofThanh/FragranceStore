
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
                <div class="col-sm-3">
                    <div class="card bg-light mb-3">
                        <div class="card-header bg-primary text-white text-uppercase"><i class="fa fa-list"></i> Categories</div>
                        <ul class="list-group category_block">
                            <c:forEach items="${listCC}" var="o">
                                <li class="list-group-item text-white ${tag == o.cid ? "active":""}"><a href="category?cid=${o.cid}">${o.cname}</a></li>
                            </c:forEach>

                        </ul>
                    </div>
                    <div class="card bg-light mb-3">
                        <div class="card-header bg-success text-white text-uppercase">Last product</div>
                        <div class="card-body">
                            <img class="img-fluid" src="${p.image}" />
                            <h5 class="card-title">${p.name}</h5>
<!--                                        <c:choose>  
                                            <c:when test="${p.review>=4.5}">  
                                                <p class="card-text">                                                
                                                    <span class="fa fa-star checked"></span>                   
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star checked"></span>
                                                    <span>${p.review}</span>
                                                </p>
                                            </c:when>  
                                            <c:when test="${p.review>=3.5}">  
                                                <p class="card-text">
                                                
                                                    <span class="fa fa-star checked"></span>                   
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star"></span>
                                                    <span>${p.review}</span>
                                                </p>                                                
                                            </c:when>
                                            <c:when test="${p.review>=2.5}">  
                                                <p class="card-text">
                                                
                                                    <span class="fa fa-star checked"></span>                   
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star"></span>
                                                    <span>${p.review}</span>
                                                    </p>
                                            </c:when>
                                            <c:when test="${p.review>=1.5}">  
                                                <p class="card-text">
                                                
                                                    <span class="fa fa-star checked"></span>                   
                                                    <span class="fa fa-star checked"></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star"></span>
                                                    <span>${p.review}</span>
                                                    </p>
                                            </c:when>
                                            <c:when test="${p.review>0}">  
                                                <p class="card-text">
                                                
                                                    <span class="fa fa-star checked"></span>                   
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star"></span>
                                                    <span>${p.review}</span>
                                                    </p>
                                            </c:when>                                                    
                                            <c:otherwise>  
                                                <p class="card-text">
                                                    <span class="fa fa-star "></span>                   
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star "></span>
                                                    <span class="fa fa-star "></span>
                                                    <span>${p.review}</span>  
                                                </p>    
                                            </c:otherwise>  
                                        </c:choose>                            -->
                            <p class="bloc_left_price">${p.price} $</p>
                        </div>
                    </div>
                </div>
