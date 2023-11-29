<%-- 
    Document   : Review
    Created on : Jul 7, 2023, 1:11:38 PM
    Author     : admin
--%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

        <style>
                .print{margin-top:20px;
                background:#eee;
                }
                .review-list ul li .left span {
                     width: 32px;
                     height: 32px;
                     display: inline-block;
                }
                 .review-list ul li .left {
                     flex: none;
                     max-width: none;
                     margin: 0 10px 0 0;
                }
                 .review-list ul li .left span img {
                     border-radius: 50%;
                }
                 .review-list ul li .right h4 {
                     font-size: 16px;
                     margin: 0;
                     display: flex;
                }
                 .review-list ul li .right h4 .gig-rating {
                     display: flex;
                     align-items: center;
                     margin-left: 10px;
                     color: #ffbf00;
                }
                 .review-list ul li .right h4 .gig-rating svg {
                     margin: 0 4px 0 0px;
                }
                 .country .country-flag {
                     width: 16px;
                     height: 16px;
                     vertical-align: text-bottom;
                     margin: 0 7px 0 0px;
                     border: 1px solid #fff;
                     border-radius: 50px;
                     box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);
                }
                 .country .country-name {
                     color: #95979d;
                     font-size: 13px;
                     font-weight: 600;
                }
                 .review-list ul li {
                     border-bottom: 1px solid #dadbdd;
                     padding: 0 0 30px;
                     margin: 0 0 30px;
                }
                 .review-list ul li .right {
                     flex: auto;
                }
                 .review-list ul li .review-description {
                     margin: 20px 0 0;
                }
                 .review-list ul li .review-description p {
                     font-size: 14px;
                     margin: 0;
                }
                 .review-list ul li .publish {
                     font-size: 13px;
                     color: #95979d;
                }

                .review-section h4 {
                     font-size: 20px;
                     color: #222325;
                     font-weight: 700;
                }
                 .review-section .stars-counters tr .stars-filter.fit-button {
                     padding: 6px;
                     border: none;
                     color: #4a73e8;
                     text-align: left;
                }
                 .review-section .fit-progressbar-bar .fit-progressbar-background {
                     position: relative;
                     height: 8px;
                     background: #efeff0;
                     -webkit-box-flex: 1;
                     -ms-flex-positive: 1;
                     flex-grow: 1;
                     box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);
                     background-color: #ffffff;
                    ;
                     border-radius: 999px;
                }
                 .review-section .stars-counters tr .star-progress-bar .progress-fill {
                     background-color: #ffb33e;
                }
                 .review-section .fit-progressbar-bar .progress-fill {
                     background: #2cdd9b;
                     background-color: rgb(29, 191, 115);
                     height: 100%;
                     position: absolute;
                     left: 0;
                     z-index: 1;
                     border-radius: 999px;
                }
                 .review-section .fit-progressbar-bar {
                     display: flex;
                     align-items: center;
                }
                 .review-section .stars-counters td {
                     white-space: nowrap;
                }
                 .review-section .stars-counters tr .progress-bar-container {
                     width: 100%;
                     padding: 0 10px 0 6px;
                     margin: auto;
                }
                 .ranking h6 {
                     font-weight: 600;
                     padding-bottom: 16px;
                }
                 .ranking li {
                     display: flex;
                     justify-content: space-between;
                     color: #95979d;
                     padding-bottom: 8px;
                }
                 .review-section .stars-counters td.star-num {
                     color: #4a73e8;
                }
                 .ranking li>span {
                     color: #62646a;
                     white-space: nowrap;
                     margin-left: 12px;
                }
                 .review-section {
                     border-bottom: 1px solid #dadbdd;
                     padding-bottom: 24px;
                     margin-bottom: 34px;
                     padding-top: 64px;
                }
                 .review-section select, .review-section .select2-container {
                     width: 188px !important;
                     border-radius: 3px;
                }
                ul, ul li {
                    list-style: none;
                    margin: 0px;
                }
                .helpful-thumbs, .helpful-thumb {
                    display: flex;
                    align-items: center;
                    font-weight: 700;
                }
                
                
                .review {
                  max-width: 400px;
                  margin: 0 auto;
                  padding: 20px;
                  background-color: #f2f2f2;
                  border-radius: 5px;
                  font-family: Arial, sans-serif;
                }

                label {
                  display: block;
                  margin-bottom: 10px;
                  font-weight: bold;
                }

                input[type="text"],
                textarea {
                  width: 100%;
                  padding: 8px;
                  border-radius: 3px;
                  border: 1px solid #ccc;
                }

                textarea {
                  height: 100px;
                }

                input[type="submit"] {
                  padding: 10px 20px;
                  background-color: #4CAF50;
                  border: none;
                  color: white;
                  cursor: pointer;
                }

                input[type="submit"]:hover {
                  background-color: #45a049;
                }                
        </style>  

    <div class="container">
<div class="print">
        <div class="container">
            <div id="reviews" class="review-section">
                <div class="d-flex align-items-center justify-content-between mb-4">
                    <h4 class="m-0">Ðánh giá</h4>
<!--                    <select class="custom-select custom-select-sm border-0 shadow-sm ml-2 select2-hidden-accessible" data-select2-id="1" tabindex="-1" aria-hidden="true">
                        <option data-select2-id="3">Most Relevant</option>
                        <option>Most Recent</option>
                    </select>-->
                    <span class="select2 select2-container select2-container--default" dir="ltr" data-select2-id="2" style="width: 188px;">
                        <span class="selection">
                            <span class="select2-selection select2-selection--single" role="combobox" aria-haspopup="true" aria-expanded="false" tabindex="0" aria-labelledby="select2-qd66-container">
                                <span class="select2-selection__rendered" id="select2-qd66-container" role="textbox" aria-readonly="true" title="Most Relevant"></span>
                                <span class="select2-selection__arrow" role="presentation"><b role="presentation"></b></span>
                            </span>
                        </span>
                        <span class="dropdown-wrapper" aria-hidden="true"></span>
                    </span>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <table class="stars-counters">
                            <tbody>
                                <tr class="">
                                    <td>
                                        <span>
                                            <button class="fit-button fit-button-color-blue fit-button-fill-ghost fit-button-size-medium stars-filter"><a href="asdad">5 Stars</a></button>
                                        </span>
                                    </td>
                                    <td class="progress-bar-container">
                                        <div class="fit-progressbar fit-progressbar-bar star-progress-bar">
                                            <div class="fit-progressbar-background">
                                                <span class="progress-fill" style="width: ${percent[4]}%;"></span>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="star-num">(${listS.get(4).sao})</td>
                                </tr>
                                <tr class="">
                                    <td>
                                        <span>
                                            <button class="fit-button fit-button-color-blue fit-button-fill-ghost fit-button-size-medium stars-filter">4 Stars</button>
                                        </span>
                                    </td>
                                    <td class="progress-bar-container">
                                        <div class="fit-progressbar fit-progressbar-bar star-progress-bar">
                                            <div class="fit-progressbar-background">
                                                <span class="progress-fill" style="width: ${percent[3]}%;"></span>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="star-num">(${listS.get(3).sao})</td>
                                </tr>
                                <tr class="">
                                    <td>
                                        <span>
                                            <button class="fit-button fit-button-color-blue fit-button-fill-ghost fit-button-size-medium stars-filter">3 Stars</button>
                                        </span>
                                    </td>
                                    <td class="progress-bar-container">
                                        <div class="fit-progressbar fit-progressbar-bar star-progress-bar">
                                            <div class="fit-progressbar-background">
                                                <span class="progress-fill" style="width: ${percent[2]}%;"></span>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="star-num">(${listS.get(2).sao})</td>
                                </tr>
                                <tr class="">
                                    <td>
                                        <span>
                                            <button class="fit-button fit-button-color-blue fit-button-fill-ghost fit-button-size-medium stars-filter">2 Stars</button>
                                        </span>
                                    </td>
                                    <td class="progress-bar-container">
                                        <div class="fit-progressbar fit-progressbar-bar star-progress-bar">
                                            <div class="fit-progressbar-background">
                                                <span class="progress-fill" style="width: ${percent[1]}%;"></span>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="star-num">(${listS.get(1).sao})</td>
                                </tr>
                                <tr class="">
                                    <td>
                                        <span>
                                            <button class="fit-button fit-button-color-blue fit-button-fill-ghost fit-button-size-medium stars-filter">1 Stars</button>
                                        </span>
                                    </td>
                                    <td class="progress-bar-container">
                                        <div class="fit-progressbar fit-progressbar-bar star-progress-bar">
                                            <div class="fit-progressbar-background">
                                                <span class="progress-fill" style="width: ${percent[0]}%;"></span>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="star-num">(${listS.get(0).sao})</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="col-md-6">
                        <div class="ranking">
                            <h6 class="text-display-7">Phân tích xếp hạng</h6>
                            <ul>
                                <li>
                                    Tổng số đánh giá<span>${soCmt}<span class="review-star rate-10 show-one"></span></span>
                                </li>
                                <li>
                                    Ðánh giá trung bình:<span>${averageStar}*<span class="review-star rate-10 show-one"></span></span>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="review-list">
                <ul>                        
                    <c:forEach items="${listR}" var="o">
                    <li>
                        <div class="d-flex">
<!--                            <div class="left">
                                <span>
                                    <img src="https://bootdey.com/img/Content/avatar/avatar1.png" class="profile-pict-img img-fluid" alt="" />
                                </span>
                            </div>-->
                            <div class="right">
                                <h4>
                                    ${o.nameuser}
                                    <span class="gig-rating text-body-2">
                                        <c:if test = "${o.sao!=null}">
                            
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1792 1792" width="15" height="15">
                                            <path
                                                fill="currentColor"
                                                d="M1728 647q0 22-26 48l-363 354 86 500q1 7 1 20 0 21-10.5 35.5t-30.5 14.5q-19 0-40-12l-449-236-449 236q-22 12-40 12-21 0-31.5-14.5t-10.5-35.5q0-6 2-20l86-500-364-354q-25-27-25-48 0-37 56-46l502-73 225-455q19-41 49-41t49 41l225 455 502 73q56 9 56 46z"
                                            ></path>
                                        </svg>
                                        </c:if>
                                        ${o.sao}
                                    </span>
                                </h4>
                                <div class="review-description">
                                    <p>
                                        ${o.comment}
                                    </p>
                                </div>
                                <span class="publish py-3 d-inline-block w-100">Published ${o.date}</span>
                            </div>
                        </div>
                    </li>
                    </c:forEach>
                </ul>
            </div>
   
                           <c:if test = "${sessionScope.acc!=null}">
  <div class="review">
    <h2>Đánh giá sản phẩm</h2>
    <form action="detail" method="post">
        
        <input type="text" style="display: none" name="id" value="${detail.id}">
        <input type="text" style="display:  none" name="date" id="currentDateInput">
        <input type="text" style="display:  none" name="name" value="${sessionScope.acc.password}">
        
<!--      <label for="name">Họ và tên:</label>
      <input type="text" id="name" name="name" required>

      <label for="email">Mã đơn hàng bạn đã mua:</label>
      <input type="text" id="madh" name="madh" required>-->
        <c:if test = "${flag==false}">      
      <label for="rating">Đánh giá:</label>
      <select id="rating" name="rating" required>
        <option value="">-- Chọn đánh giá --</option>
        <option value="5">5 sao - Tuyệt vời</option>
        <option value="4">4 sao - Rất tốt</option>
        <option value="3">3 sao - Trung bình</option>
        <option value="2">2 sao - Kém</option>
        <option value="1">1 sao - Rất kém</option>
      </select>
      </c:if>   
      <label for="review">Nhận xét:</label>
      <textarea id="review" name="review" required></textarea>

      <input type="submit" value="Gửi đánh giá">
    </form>
        <p style="color: red; font-style: italic; font-weight: bold">${sessionScope.errorMsg}</p>        
  </div>
                        </c:if>                             
                        <c:if test = "${sessionScope.acc==null}">
        <p style="color: green; font-style: italic; font-weight: bold">Đăng nhập để đánh giá</p>        

                        </c:if>                                

        
        </div>
    </div>
  </div>                        
    </div>
    
    
<script>
  var currentDateInput = document.getElementById("currentDateInput");
  var currentDate = new Date();
  var dateString = currentDate.toLocaleDateString();
  currentDateInput.value = dateString;
    window.addEventListener("beforeunload", function(event) {
        // Xóa dữ liệu trong session
        sessionStorage.clear();
    });

</script>