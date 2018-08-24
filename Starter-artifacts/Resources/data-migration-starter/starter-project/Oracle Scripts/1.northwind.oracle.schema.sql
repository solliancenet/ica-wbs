-- 1. Run to drop schema
--drop user NW cascade;

-- 2. Run to create user and schema 
CREATE USER NW IDENTIFIED BY Password
  DEFAULT TABLESPACE users
  TEMPORARY TABLESPACE temp
  QUOTA UNLIMITED ON users
  ;
-- 3. Run to grant permissions
GRANT "CONNECT" TO NW;
GRANT DBA TO NW;
GRANT "RESOURCE" TO NW;
ALTER USER NW DEFAULT ROLE "CONNECT",
                                  DBA,
                                  "RESOURCE";


ALTER USER NW IDENTIFIED BY oracledemo123;

--select s.sid, s.serial#, s.status, p.spid 
-- from v$session s, v$process p 
-- where s.username = 'NW' 
-- and p.addr (+) = s.paddr;
 
-- -- alter system kill session '<sid>,<serial#>';