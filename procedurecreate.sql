create or replace PROCEDURE DELETE_flowers
(
  p_id flowers.id%TYPE
)
AS
  v_orderCount INT;
BEGIN
  SELECT COUNT(*) INTO v_orderCount FROM orders WHERE flowerid = p_id;

  IF v_orderCount != 0 THEN
    DELETE FROM orders WHERE flowerid = p_id;
  END IF;

  DELETE FROM flowers WHERE id = p_id;
  COMMIT;
END;


create or replace PROCEDURE DELETE_customers
(
  p_id customers.id%TYPE
)
AS
  v_orderCount INT;
BEGIN
  SELECT COUNT(*) INTO v_orderCount FROM orders WHERE customerid = p_id;

  IF v_orderCount != 0 THEN
    DELETE FROM orders WHERE customerid = p_id;
  END IF;

  DELETE FROM customers WHERE id = p_id;
  COMMIT;
END;


create or replace PROCEDURE Insert_orders
(
  p_customerName customers.name%TYPE,
  p_customerPhoneNumber customers.phoneNumber%TYPE,
  p_customerEmail customers.email%TYPE,
  p_customerAddress customers.address%TYPE,
  p_flowerName flowers.name%TYPE,
  p_quantity orders.quantity%TYPE,
  p_isCompleted orders.isCompleted%TYPE,
  p_isDeliveryRequested orders.isDeliveryRequested%TYPE
)
AS
  v_customerCnt INT;
  v_availableFlowerQuantity flowers.quantity%TYPE;
  v_flowerId flowers.id%TYPE;
  v_alreadyExistingOrderCnt INT;
  v_customerId customers.id%TYPE
BEGIN
  SELECT id, quantity INTO v_flowerId, v_availableFlowerQuantity FROM flowers WHERE name = p_flowerName;  
  SELECT COUNT(*) INTO v_customerCnt FROM customers WHERE name = p_customerName AND phoneNumber = p_customerPhoneNumber AND email = p_customerEmail AND address = p_customerAddress;
  
  IF v_availableFlowerQuantity < p_quantity THEN
	RETURN;
  END IF
  
  IF v_customerCnt = 0 THEN
	INSERT INTO customers(name, phoneNumber, email, address) VALUES (p_customerName, p_customerPhoneNumber, p_customerEmail, p_customerAddress);
  END IF
  
  SELECT id INTO v_customerId FROM custommers WHERE name = p_customerName AND phoneNumber = p_customerPhoneNumber AND email = p_customerEmail AND address = p_customerAddress;  
  
  SELECT COUNT(*) INTO v_alreadyExistingOrderCnt FROM orders WHERE flowerId = v_flowerId AND customerId = v_customerId;
  
  IF v_alreadyExistingOrderCnt > THEN
	RETURN;
  END IF
  
  INSERT INTO orders(customerId, flowerId, quantity, isCompleted, isDeliveryRequested) VALUES (v_customerId, v_flowerId, p_quantity, p_isCompleted, p_isDeliveryRequested);
  COMMIT;
END;



create or replace PROCEDURE Update_customers
(
  p_id customers.id%TYPE,
  p_name customers.name%TYPE,
  p_zipcode customers.cityid%TYPE,
  p_city city.name%TYPE,
  p_address customers.address%TYPE
)
AS
  v_exist INT;
BEGIN
  SELECT COUNT(*) INTO v_exist FROM city WHERE zipcode = p_zipcode;
  IF v_exist = 0 THEN
    INSERT INTO city(zipcode, name) VALUES(p_zipcode, p_city);
  END IF;
  UPDATE customers SET name = p_name, cityid = p_zipcode, address = p_address WHERE id = p_id;
  COMMIT;
END;



create or replace PROCEDURE Update_flowers
(
  p_id flowers.id%TYPE,
  p_name flowers.name%TYPE,
  p_type flowers.type%TYPE,
  p_color flowers.color%TYPE
)
AS
BEGIN
  UPDATE flowers SET name = p_name, type = p_type, color = p_color WHERE id = p_id;
  COMMIT;
END;