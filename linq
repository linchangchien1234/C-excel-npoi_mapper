IEnumerable<object> list;
            using (ESDEntities db = new ESDEntities())
            {
                var p = (from aa in db.ESD_CARD
                         join bb in db.ESD_REC
                         on aa.CARD equals bb.CARD_ID
                         join cc in db.ESD_ADD_REF
                         on bb.ADDRESS equals cc.ADDRESS
                         join dd in db.ESD_EMP
                          on aa.EMP_NO equals dd.EMP_NO
                         select new { aa, bb, cc, dd });
                //p = p.Where(a => a.aa.EMP_NO == "1000002");

                
                if (!string.IsNullOrEmpty(data.EMP_NO))
                {
                    p = p.Where(a => a.aa.EMP_NO == data.EMP_NO);
                }

                if (!string.IsNullOrEmpty(data.NAME))
                {
                    p = p.Where(a => a.dd.NAME == data.NAME);
                }
                if (!string.IsNullOrEmpty(data.CARD_ID))
                {
                    p = p.Where(a => a.bb.CARD_ID == data.CARD_ID);
                }
                if (!string.IsNullOrEmpty(data.TEST_DATE_START))
                {

                    // int.Parse 轉換型態linq有問題
                    p = p.Where(a => int.Parse(a.bb.TEST_DATE) >= int.Parse(data.TEST_DATE_START));
                }
                if (!string.IsNullOrEmpty(data.TEST_TIME_START))
                {
                    p = p.Where(a => int.Parse(a.bb.TEST_Time) >= int.Parse(data.TEST_TIME_START));
                }
                if (!string.IsNullOrEmpty(data.TEST_DATE_END))
                {
                    p = p.Where(a => int.Parse(a.bb.TEST_DATE) <= int.Parse(data.TEST_DATE_END));
                }
                if (!string.IsNullOrEmpty(data.TEST_TIME_END))
                {
                    p = p.Where(a => int.Parse(a.bb.TEST_Time) <= int.Parse(data.TEST_TIME_END));
                }
                if (!string.IsNullOrEmpty(data.ADDRESS_ID))
                {
                    p = p.Where(a => a.cc.ADDRESS_ID == data.ADDRESS_ID);
                }
                list = p.Take(50).ToList();
            }
            var abc = list;
            return list;
