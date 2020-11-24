--1
SELECT
	v.datetime AS visit_datetime,
    v.bp_systolic,
    v.bp_diastolic,
    CONCAT(un.last_name, ', ', un.first_name) AS nurse_name,
    v.nurse_user_id,
    CONCAT(ud.last_name, ', ', ud.first_name) AS doctor_name,
    v.doctor_id,
    (SELECT GROUP_CONCAT(h.test_code, ': ',  t.name SEPARATOR ', ') FROM has_tests h
        LEFT OUTER JOIN lab_test t
        	ON h.test_code = t.code
        LEFT OUTER JOIN lab_test_order o 
        	ON o.order_id = h.order_id
        WHERE o.patient_id = v.patient_id AND o.visit_datetime = v.datetime) AS tests_ordered,
    (SELECT GROUP_CONCAT(h.test_code, ': ',  r.results SEPARATOR ', ') FROM has_tests h 
        LEFT OUTER JOIN lab_test_result r
        	ON h.order_id = r.order_id AND h.test_code = r.test_code
        LEFT OUTER JOIN lab_test_order o 
        	ON o.order_id = h.order_id
        WHERE o.patient_id = v.patient_id AND o.visit_datetime = v.datetime) AS results,
    v.diagnoses
FROM 
	visit v, user un, doctor d, user ud
WHERE 
	v.nurse_user_id = un.user_id AND 
    v.doctor_id = d.doctor_id AND 
    d.user_id = ud.user_id AND
    v.patient_id = (SELECT patient_id FROM patient WHERE user_id = (SELECT user_id FROM user WHERE first_name = 'Li' AND last_name = 'Yang'));

--2
SELECT 
	o.patient_id, 
    CONCAT(u.first_name, ' ', u.last_name) AS patient_name, 
    DATE(r.datetime_taken) AS date_taken, 
    COUNT(r.order_id AND DATE(r.datetime_taken)) AS num_tests_taken
FROM lab_test_result r, lab_test_order o, patient p, user u
WHERE
	o.order_id = r.order_id AND
    p.patient_id = o.patient_id AND
    u.user_id = p.user_id
GROUP BY r.order_id, date_taken
HAVING COUNT(r.order_id AND date_taken) > 1
ORDER BY o.patient_id, date_taken;